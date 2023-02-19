using Lmoe.Domain.Enums;

namespace Lmoe.Domain.Models.ValueObjects;

public class Damage
{
    public DiceType Dice { get; }

    public int DiceAmount { get; }

    // TODO: Validate that at least 1 dmg type specified
    public IReadOnlyCollection<DamageType> Types { get; }
}
