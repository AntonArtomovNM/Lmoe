using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Contracts;

namespace Lmoe.Domain.Models.Entities;

public class Trait : SourceMaterialBase
{
    public TraitType Type { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    private Trait() 
    {
    }

    public static Trait Create(SourceType source, TraitType type, string name, string description)
    {
        var trait = new Trait();

        trait.SetSource(source);
        trait.SetTraitType(type);
        trait.SetTraitInfo(name, description);

        return trait;
    }

    public void SetTraitInfo(string name, string description)
    {
        Name = name;
        Description = description;

        UpdatedAt = DateTimeOffset.UtcNow;
    }

    private void SetTraitType(TraitType type)
    {
        // TODO: Add validation for a 1 time operation
        Type = type;

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
