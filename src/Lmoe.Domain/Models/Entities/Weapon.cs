using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Models.ValueObjects;
using Lmoe.Domain.Validation;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.Entities;

public class Weapon : EquipmentBase, ITraitTaggable
{
    // Common
    public WeaponType Type { get; private set; }

    public Damage? Damage { get; private set; }

    public IReadOnlyCollection<TraitTag> Traits { get; private set; }

    // Depends on weapon type
    public string? Range { get; private set; }

    public AmmunitionType? AmmoType { get; private set; }

    private Weapon()
    {
    }

    public static Result<Weapon> CreateMelee(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        bool isMartial,
        Damage? damage,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        return Result.Aggregate(
            value: weapon,
            weapon.SetSource(source),
            weapon.SetEquipmentInfo(name, weight, price, isRare, description),
            weapon.SetMeleeWeaponInfo(isMartial, damage, traits));
    }

    public static Result<Weapon> CreateRanged(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        bool isMartial,
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        return Result.Aggregate(
            value: weapon,
            weapon.SetSource(source),
            weapon.SetEquipmentInfo(name, weight, price, isRare, description),
            weapon.SetRangedWeaponInfo(isMartial, damage, range, ammoType, traits));
    }

    public static Result<Weapon> CreateFirearm(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        return Result.Aggregate(
            value: weapon,
            weapon.SetSource(source),
            weapon.SetEquipmentInfo(name, weight, price, isRare, description),
            weapon.SetFirearmInfo(damage, range, ammoType, traits));
    }

    public Result SetMeleeWeaponInfo(
        bool isMartial,
        Damage? damage,
        IReadOnlyCollection<TraitTag> traits)
    {
        var validation = WeaponValidator.ValidateDamage(damage);

        if (validation.IsFailure)
        {
            return validation;
        }

        Type = isMartial ? WeaponType.MartialMelee : WeaponType.SimpleMelee;
        Damage = damage;
        Range = null;
        AmmoType = null;
        Traits = traits;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }

    public Result SetRangedWeaponInfo(
        bool isMartial,
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        var validation = Result.Aggregate(
            WeaponValidator.ValidateDamage(damage),
            WeaponValidator.ValidateRange(range),
            WeaponValidator.ValidateAmmoTypeForRangedWeapon(ammoType));

        if (validation.IsFailure)
        {
            return validation;
        }

        Type = isMartial ? WeaponType.MartialRanged : WeaponType.SimpleRanged;
        Damage = damage;
        Range = range;
        AmmoType = ammoType;
        Traits = traits;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }

    public Result SetFirearmInfo(
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        var validation = Result.Aggregate(
            WeaponValidator.ValidateDamage(damage),
            WeaponValidator.ValidateRange(range),
            WeaponValidator.ValidateAmmoTypeForFirearms(ammoType));

        if (validation.IsFailure)
        {
            return validation;
        }

        Type = WeaponType.Firearm;
        Damage = damage;
        Range = range;
        AmmoType = ammoType;
        Traits = traits;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }
}
