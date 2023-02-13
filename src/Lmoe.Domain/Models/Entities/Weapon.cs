using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities;

public class Weapon : BaseEquipment
{
    public WeaponType Type { get; private set; }

    public Damage Damage { get; private set; }

    public IEnumerable<TraitTag> Traits { get; private set; }

    public string? Range { get; private set; }

    public AmmunitionType? AmmoType { get; private set; }

    public BulletPack? BulletPack { get; private set; }

    private Weapon()
    {
    }

    public static Weapon CreateMeleeWeapon(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage damage,
        IEnumerable<TraitTag> traits)
    {
        return new()
        {
            Source = source,
            Name = name,
            Weight = weight,
            Price = price,
            IsRare = isRare,
            Description = description,
            Type = type,
            Damage = damage,
            Traits = traits,
        };
    }

    public static Weapon CreateRangedWeapon(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string range,
        AmmunitionType ammoType)
    {
        return new()
        {
            Source = source,
            Name = name,
            Weight = weight,
            Price = price,
            IsRare = isRare,
            Description = description,
            Type = type,
            Damage = damage,
            Traits = traits,
            Range = range,
            AmmoType = ammoType,
        };
    }

    public static Weapon CreateFirearm(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string range,
        BulletPack bulletPack)
    {
        return new()
        {
            Source = source,
            Name = name,
            Weight = weight,
            Price = price,
            IsRare = isRare,
            Description = description,
            Type = WeaponType.Firearm,
            Damage = damage,
            Traits = traits,
            Range = range,
            AmmoType = AmmunitionType.Bullet,
            BulletPack = bulletPack,
        };
    }

    public static Weapon CreateImprovisedWeapon(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string? range)
    {
        return new()
        {
            Source = source,
            Name = name,
            Weight = weight,
            Price = price,
            IsRare = isRare,
            Description = description,
            Type = WeaponType.Improvised,
            Damage = damage,
            Traits = traits,
            Range = range,
        };
    }

    public void UpdateMeleeWeapon(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage damage,
        IEnumerable<TraitTag> traits)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        Type = type;
        Damage = damage;
        Traits = traits;
        Range = null;
        AmmoType = null;
        BulletPack = null;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateRangedWeapon(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        WeaponType type,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string range,
        AmmunitionType ammoType)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        Type = type;
        Damage = damage;
        Traits = traits;
        Range = range;
        AmmoType = ammoType;
        BulletPack = null;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateFirearm(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string range,
        BulletPack bulletPack)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        Type = WeaponType.Firearm;
        Damage = damage;
        Traits = traits;
        Range = range;
        AmmoType = AmmunitionType.Bullet;
        BulletPack = bulletPack;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateImprovisedWeapon(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        Damage damage,
        IEnumerable<TraitTag> traits,
        string? range)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        Type = WeaponType.Improvised;
        Damage = damage;
        Traits = traits;
        Range = range;
        AmmoType = null;
        BulletPack = null;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
