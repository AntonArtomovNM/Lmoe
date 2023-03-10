namespace Lmoe.Domain.Models.ValueObjects;

public class Money
{
    public int Pp { get; }

    public int Gp { get; }

    public int Sp { get; }

    public int Cp { get; }

    public bool IsZero()
    {
        return Pp is 0 && Gp is 0 && Sp is 0 && Cp is 0;
    }
}
