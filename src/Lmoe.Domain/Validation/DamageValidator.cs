using Lmoe.Domain.Enums;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Validation;

internal static class DamageValidator
{
    private const int MinDiceAmount = 1;
    private const int MaxDiceAmount = 100;

    public static Result ValidateDiceAmount(int amount)
    {
        if (amount is < MinDiceAmount or > MaxDiceAmount)
        {
            return Result.Failure($"Weapon damage dice amount must be a value between {MinDiceAmount} and {MaxDiceAmount}");
        }

        return Result.Success();
    }

    public static Result ValidateDamageTypes(IEnumerable<DamageType> types)
    {
        if (types is null || !types.Any())
        {
            return Result.Failure($"Weapon damage needs to have at least one damage type specified");
        }

        return Result.Success();
    }
}
