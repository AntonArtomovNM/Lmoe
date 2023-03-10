using Lmoe.Domain.Models.ValueObjects;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Validation;

internal static class EquipmentValidator
{
    private const int MaxNameLength = 35;
    private const int MaxDescriptionLength = 200;
    private const int MinWeightValue = 0;
    private const int MaxWeightValue = 100;

    public static Result ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure("Equipment name is required");
        }

        if (name.Length > MaxNameLength)
        {
            return Result.Failure($"Equipment name cannot be longer than {MaxNameLength} characters");
        }

        return Result.Success();
    }

    public static Result ValidateDescription(string? description)
    {
        if (description is not null && description.Length > MaxDescriptionLength)
        {
            return Result.Failure($"Equipment description cannot be longer than {MaxDescriptionLength} characters");
        }

        return Result.Success();
    }

    public static Result ValidateWeight(float weight)
    {
        if (weight is < MinWeightValue or > MaxWeightValue)
        {
            return Result.Failure($"Equipment weight must be a value between {MinWeightValue} and {MaxWeightValue}");
        }

        return Result.Success();
    }

    public static Result ValidatePrice(Money price)
    {
        if (price is null)
        {
            return Result.Failure($"Equipment price is required");
        }

        return Result.Success();
    }
}
