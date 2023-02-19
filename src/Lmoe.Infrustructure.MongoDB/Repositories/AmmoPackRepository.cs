using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class AmmoPackRepository : RepositoryBase<AmmoPack>, IAmmoPackRepository
{
    public AmmoPackRepository(IMongoCollection<AmmoPack> mongoCollection) : base(mongoCollection)
    {
    }

    public async Task Create(AmmoPack ammoPack)
    {
        await _mongoCollection.InsertOneAsync(ammoPack);
    }

    public async Task Update(AmmoPack ammoPack)
    {
        await _mongoCollection.ReplaceOneAsync(GetIdFilter(ammoPack.Id), ammoPack);
    }

    public async Task<AmmoPack> GetById(Guid id)
    {
        return await _mongoCollection.Find(GetIdFilter(id)).FirstOrDefaultAsync();
    }

    public async Task<ICollection<AmmoPack>> GetAll()
    {
        return await _mongoCollection.Find(GetNotDeletedFilted()).ToListAsync();
    }
}
