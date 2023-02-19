using Lmoe.Domain.Models.Entities;

namespace Lmoe.Domain.Repositories;

public interface IWeaponRepository
{
    Task Create(Weapon weapon);

    Task Update(Weapon weapon);

    Task<Weapon> GetById(Guid id);

    Task<ICollection<Weapon>> GetAll();
}
