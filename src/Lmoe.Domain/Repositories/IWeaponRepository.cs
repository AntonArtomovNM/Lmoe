using Lmoe.Domain.Models.Entities;

namespace Lmoe.Domain.Repositories;

public interface IWeaponRepository : IRepository<Weapon>
{
    Task RemoveTraitTag(Guid traitId);
}
