using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.ValueObjects;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Validation;

internal static class WeaponValidator
{
    private const int MaxRangeLength = 15;

    public static Result ValidateDamage(Damage? damage)
    {
        // Damage is optional
        if (damage is null)
        {
            return Result.Success();
        }

        return Result.Aggregate(
            DamageValidator.ValidateDiceAmount(damage.DiceAmount),
            DamageValidator.ValidateDamageTypes(damage.Types));
    }

    public static Result ValidateRange(string range)
    {
        if (string.IsNullOrWhiteSpace(range))
        {
            return Result.Failure("Weapon range is required");
        }

        if (range.Length > MaxRangeLength)
        {
            return Result.Failure($"Weapon range cannot be longer than {MaxRangeLength}");
        }

        return Result.Success();
    }

    public static Result ValidateAmmoTypeForRangedWeapon(AmmunitionType ammoType)
    {
        return ammoType is AmmunitionType.LightBullet or AmmunitionType.HeavyBullet
            ? Result.Failure($"Ranged weapons cannot use bullets")
            : Result.Success();
    }

    public static Result ValidateAmmoTypeForFirearms(AmmunitionType ammoType)
    {
        return ammoType is not AmmunitionType.LightBullet or AmmunitionType.HeavyBullet
            ? Result.Failure($"Firearms can only use bullets")
            : Result.Success();
    }
}
