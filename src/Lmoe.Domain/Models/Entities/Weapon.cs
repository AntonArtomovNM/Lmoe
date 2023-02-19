using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Models.ValueObjects;

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

    public BulletPack? BulletPack { get; private set; }

    private Weapon()
    {
    }

    public static Weapon CreateMelee(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage? damage,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        weapon.SetSource(source);
        weapon.SetEquipmentInfo(name, weight, price, isRare, description);
        weapon.SetMeleeWeaponInfo(type, damage, traits);

        return weapon;
    }

    public static Weapon CreateRanged(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        weapon.SetSource(source);
        weapon.SetEquipmentInfo(name, weight, price, isRare, description);
        weapon.SetRangedWeaponInfo(type, damage, range, ammoType, traits);

        return weapon;
    }

    public static Weapon CreateFirearm(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage? damage,
        string range,
        BulletPack bulletPack,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        weapon.SetSource(source);
        weapon.SetEquipmentInfo(name, weight, price, isRare, description);
        weapon.SetFirearmInfo(damage, range, bulletPack, traits);

        return weapon;
    }

    public static Weapon CreateImprovised(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage? damage,
        string? range,
        IReadOnlyCollection<TraitTag> traits)
    {
        var weapon = new Weapon();

        weapon.SetSource(source);
        weapon.SetEquipmentInfo(name, weight, price, isRare, description);
        weapon.SetImprovisedWeaponInfo(damage, range, traits);

        return weapon;
    }

    public void SetMeleeWeaponInfo(
        WeaponType type,
        Damage? damage,
        IReadOnlyCollection<TraitTag> traits)
    {
        // TODO: Validate weapon type
        // TODO: Validate damage?
        Type = type;
        Damage = damage;
        Range = null;
        AmmoType = null;
        BulletPack = null;
        Traits = traits;

        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void SetRangedWeaponInfo(
        WeaponType type,
        Damage? damage,
        string range,
        AmmunitionType ammoType,
        IReadOnlyCollection<TraitTag> traits)
    {
        // TODO: Validate weapon type and ammo type
        // TODO: Validate damage?
        Type = type;
        Damage = damage;
        Range = range;
        AmmoType = ammoType;
        BulletPack = null;
        Traits = traits;

        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void SetFirearmInfo(
        Damage? damage,
        string range,
        BulletPack bulletPack,
        IReadOnlyCollection<TraitTag> traits)
    {
        // TODO: Validate bullet pack
        // TODO: Validate damage?
        Type = WeaponType.Firearm;
        Damage = damage;
        Range = range;
        AmmoType = AmmunitionType.Bullet;
        BulletPack = bulletPack;
        Traits = traits;

        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void SetImprovisedWeaponInfo(
        Damage? damage,
        string? range,
        IReadOnlyCollection<TraitTag> traits)
    {
        // TODO: Validate damage?
        Type = WeaponType.Improvised;
        Damage = damage;
        Range = range;
        AmmoType = null;
        BulletPack = null;
        Traits = traits;

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
