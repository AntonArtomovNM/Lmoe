using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Validation;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.Entities;

public class Trait : SourceMaterialBase
{
    public TraitType Type { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    private Trait() 
    {
    }

    public static Result<Trait> Create(SourceType source, TraitType type, string name, string description)
    {
        var trait = new Trait();

        return Result.Aggregate(
            value: trait,
            trait.SetSource(source),
            trait.SetTraitType(type),
            trait.SetTraitInfo(name, description));
    }

    public Result SetTraitInfo(string name, string description)
    {
        var validation = Result.Aggregate(
            TraitValidator.ValidateName(name),
            TraitValidator.ValidateDescription(description));

        if (validation.IsFailure)
        {
            return validation;
        }

        Name = name;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }

    private Result SetTraitType(TraitType type)
    {
        if (Type is not 0)
        {
            Result.Failure("Trait type cannot be changed");
        }

        Type = type;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }
}
