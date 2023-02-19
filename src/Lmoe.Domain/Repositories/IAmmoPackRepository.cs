using Lmoe.Domain.Models.Entities;

namespace Lmoe.Domain.Repositories;

public interface IAmmoPackRepository
{
    Task Create(AmmoPack ammoPack);

    Task Update(AmmoPack ammoPack);

    Task<AmmoPack> GetById(Guid id);

    Task<ICollection<AmmoPack>> GetAll();
}
