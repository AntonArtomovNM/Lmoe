using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities;

public class AmmoPack : BaseEquipment
{
    public AmmunitionType AmmoType { get; private set; }

    public int Size { get; private set; }

    private AmmoPack()
    {
    }

    public static AmmoPack Create(
        SourceType source,
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        AmmunitionType ammoType,
        int size)
    {
        return new()
        {
            Source = source,
            Name = name,
            Weight = weight,
            Price = price,
            IsRare = isRare,
            Description = description,
            AmmoType = ammoType,
            Size = size,
        };
    }

    public void Update(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description,
        AmmunitionType ammoType,
        int size)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        AmmoType = ammoType;
        Size = size;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
