using Lmoe.Utils.Results;

namespace Lmoe.Domain.Validation;

internal static class TraitValidator
{
    private const int MaxNameLength = 35;
    private const int MaxDescriptionLength = 200;

    public static Result ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure("Trait name is required");
        }

        if (name.Length > MaxNameLength)
        {
            return Result.Failure($"Trait name cannot be longer than {MaxNameLength} characters");
        }

        return Result.Success();
    }

    public static Result ValidateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure("Trait description is required");
        }

        if (description.Length > MaxDescriptionLength)
        {
            return Result.Failure($"Trait description cannot be longer than {MaxDescriptionLength} characters");
        }

        return Result.Success();
    }
}
