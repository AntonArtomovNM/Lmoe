using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Models.ValueObjects;
using Lmoe.Domain.Validation;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.Entities;

public class AmmoPack : EquipmentBase
{
    public AmmunitionType AmmoType { get; private set; }

    public int Size { get; private set; }

    private AmmoPack()
    {
    }

    public static Result<AmmoPack> Create(
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

        return Result.Aggregate(
            value: ammoPack,
            ammoPack.SetSource(source),
            ammoPack.SetEquipmentInfo(name, weight, price, isRare, description),
            ammoPack.SetAmmoPackInfo(ammoType, size));
    }

    public Result SetAmmoPackInfo(AmmunitionType ammoType, int size)
    {
        var validation = AmmoPackValidator.ValidateSize(size);

        if (validation.IsFailure)
        {
            return validation;
        }

        AmmoType = ammoType;
        Size = size;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }
}
