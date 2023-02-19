using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities;

namespace Lmoe.Domain.Repositories;

public interface ITraitRepository
{
    Task Create(Trait trait);

    Task Update(Trait trait);

    Task<Trait> GetById(Guid id);

    Task<ICollection<Trait>> GetAllOfType(TraitType type);
}
