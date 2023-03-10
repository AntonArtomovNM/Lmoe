namespace Lmoe.Utils.Results;

public class Result 
{
    private readonly List<string> _errors = new();

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public IReadOnlyCollection<string> Errors => _errors;

    protected internal Result()
    {
        IsSuccess = true;
    }

    protected internal Result(string error)
    {
        if (error is null)
        {
            throw new ArgumentException("Failed result needs to have an error message");
        }

        _errors.Add(error);
        IsSuccess = false;
    }

    protected internal Result(IEnumerable<string> errors)
    {
        if (errors is null || !errors.Any())
        {
            throw new ArgumentException("Failed result needs to have an error message");
        }

        _errors.AddRange(errors);
        IsSuccess = false;
    }

    public static Result Success() => new();

    public static Result<T> Success<T>(T? value) => new(value);

    public static Result Failure(string error) => new(error);

    public static Result Failure(IEnumerable<string> errors) => new(errors);

    public static Result<T> Failure<T>(string error) => new(error);

    public static Result<T> Failure<T>(IEnumerable<string> errors) => new(errors);

    public static Result Aggregate(params Result[] results)
    {
        var errors = results
            .Where(r => r.IsFailure)
            .SelectMany(r => r.Errors);

        return errors.Any()
            ? Failure(errors)
            : Success();
    }

    public static Result<T> Aggregate<T>(T? value, params Result[] results)
    {
        var errors = results
            .Where(r => r.IsFailure)
            .SelectMany(r => r.Errors);

        return errors.Any()
            ? Failure<T>(errors)
            : Success(value);
    }
}