using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities;

public class AmmoPack : EquipmentBase
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
        var ammoPack = new AmmoPack();

        ammoPack.SetSource(source);
        ammoPack.SetEquipmentInfo(name, weight, price, isRare, description);
        ammoPack.SetAmmoPackInfo(ammoType, size);

        return ammoPack;
    }

    public void SetAmmoPackInfo(AmmunitionType ammoType, int size)
    {
        AmmoType = ammoType;
        Size = size;

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
