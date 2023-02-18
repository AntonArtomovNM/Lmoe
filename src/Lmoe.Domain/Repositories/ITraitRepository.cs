using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities;

namespace Lmoe.Domain.Repositories;

public interface ITraitRepository : IRepository<Trait>
{
    Task<ICollection<Trait>> GetAll(TraitType type);
}
