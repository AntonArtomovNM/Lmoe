using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Contracts;

namespace Lmoe.Domain.Models.Entities;

public class Trait : BaseSourceMaterial
{
    public TraitType TraitType { get; private set; }

    public string Description { get; private set; }

    private Trait() 
    {
    }

    public static Trait Create(SourceType source, string name, TraitType traitType, string description)
    {
        return new()
        {
            Source = source,
            Name = name,
            TraitType = traitType,
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
