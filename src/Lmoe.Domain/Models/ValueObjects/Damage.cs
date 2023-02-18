using Lmoe.Domain.Enums;

namespace Lmoe.Domain.Models.ValueObjects;

public class Damage
{
    public DiceType Dice { get; }

    public int DiceAmount { get; }

    public IEnumerable<DamageType> Types { get; }
}
