using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class WeaponRepository : RepositoryBase<Weapon>, IWeaponRepository
{
    public WeaponRepository(IMongoCollection<Weapon> mongoCollection)
        : base(mongoCollection)
    {
    }

    public async Task Create(Weapon weapon)
    {
        await _mongoCollection.InsertOneAsync(weapon);
    }

    public async Task Update(Weapon weapon)
    {
        await _mongoCollection.ReplaceOneAsync(GetIdFilter(weapon.Id), weapon);
    }

    public async Task<Weapon> GetById(Guid id)
    {
        return await _mongoCollection.Find(GetIdFilter(id)).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Weapon>> GetAll()
    {
        return await _mongoCollection.Find(GetNotDeletedFilted()).ToListAsync();
    }
}
