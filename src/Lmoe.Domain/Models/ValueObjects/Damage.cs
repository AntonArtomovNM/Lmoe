using Lmoe.Domain.Enums;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.ValueObjects;

public class Damage
{
    public DiceType Dice { get; }

    public int DiceAmount { get; }

    public IReadOnlyCollection<DamageType> Types { get; }
}
