using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Models.ValueObjects;
using Lmoe.Domain.Validation;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.Entities.Base;

public abstract class EquipmentBase : SourceMaterialBase
{
    public string Name { get; private set; }

    public float Weight { get; private set; }

    public Money Price { get; private set; }

    public bool IsRare { get; private set; }

    public string? Description { get; private set; }

    public Result SetEquipmentInfo(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description)
    {
        var validation = Result.Aggregate(
            EquipmentValidator.ValidateName(name),
            EquipmentValidator.ValidateWeight(weight),
            EquipmentValidator.ValidatePrice(price),
            EquipmentValidator.ValidateDescription(description));

        if (validation.IsFailure)
        {
            return validation;
        }

        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }
}
