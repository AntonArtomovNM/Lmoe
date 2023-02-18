using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities.Base;

public abstract class BaseEquipment : BaseSourceMaterial
{
    public float Weight { get; protected set; }

    public Money Price { get; protected set; }

    public bool IsRare { get; protected set; }

    public string? Description { get; protected set; }
}
