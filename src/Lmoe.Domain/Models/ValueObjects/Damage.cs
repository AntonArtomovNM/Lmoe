using Lmoe.Domain.Enums;

namespace Lmoe.Domain.Models.ValueObjects;

public class Damage
{
    public int DiceAmount { get; }

    public DiceType Dice { get; }

    public IEnumerable<DamageType> Types { get; }
}
