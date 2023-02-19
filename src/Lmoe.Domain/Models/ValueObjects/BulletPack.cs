namespace Lmoe.Domain.Models.ValueObjects;

public class BulletPack
{
    public int Size { get; }

    // TODO: Validate price not zero
    public Money Price { get; }
}
