using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Contracts;

namespace Lmoe.Domain.Models.Entities;

public class Trait : BaseSourceMaterial
{
    public TraitType Type { get; private set; }

    public string Description { get; private set; }

    private Trait() 
    {
    }

    public static Trait Create(SourceType source, string name, TraitType type, string description)
    {
        return new()
        {
            Source = source,
            Name = name,
            Type = type,
            Description = description,
        };
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
