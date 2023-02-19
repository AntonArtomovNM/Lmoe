using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities.Base;

public abstract class EquipmentBase : SourceMaterialBase
{
    public string Name { get; private set; }

    public float Weight { get; private set; }

    public Money Price { get; private set; }

    public bool IsRare { get; private set; }

    public string? Description { get; private set; }

    public void SetEquipmentInfo(
        string name,
        float weight,
        Money price,
        bool isRare,
        string? description)
    {
        Name = name;
        Weight = weight;
        Price = price;
        IsRare = isRare;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
