using Lmoe.Utils.Results;

namespace Lmoe.Domain.Validation;

internal static class AmmoPackValidator
{
    private const int MinSizeValue = 1;
    private const int MaxSizeValue = 1000;

    public static Result ValidateSize(int size)
    {
        if (size is < MinSizeValue or > MaxSizeValue)
        {
            Result.Failure($"Ammo pack size needs to be a value between {MinSizeValue} and {MaxSizeValue}");
        }

        return Result.Success();
    }
}
