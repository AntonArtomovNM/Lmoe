using Lmoe.Domain.Models.ValueObjects;

namespace Lmoe.Domain.Models.Entities.Contracts;

public interface ITraitTaggable
{
    IReadOnlyCollection<TraitTag> Traits { get; }
}
