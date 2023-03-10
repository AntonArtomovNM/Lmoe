namespace Lmoe.Utils.Results;

public class Result<T> : Result
{
    private readonly T? _value;

    protected internal Result(T? value) : base()
    {
        _value = value;
    }

    protected internal Result(string error) : base(error)
    {
    }

    protected internal Result(IEnumerable<string> errors) : base(errors)
    {
    }

    public T? Value => IsSuccess 
        ? _value
        : throw new InvalidOperationException("Failed result does not have a value");
}
