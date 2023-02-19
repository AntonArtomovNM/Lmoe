using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class TraitRepository : RepositoryBase<Trait>, ITraitRepository
{
    public TraitRepository(IMongoCollection<Trait> mongoCollection)
        : base(mongoCollection)
    {
    }

    public async Task Create(Trait trait)
    {
        await _mongoCollection.InsertOneAsync(trait);
    }

    public async Task Update(Trait trait)
    {
        await _mongoCollection.ReplaceOneAsync(GetIdFilter(trait.Id), trait);
    }

    public async Task<Trait> GetById(Guid id)
    {
        return await _mongoCollection.Find(GetIdFilter(id)).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Trait>> GetAllOfType(TraitType type)
    {
        var filter = Builders<Trait>.Filter.And(
            GetNotDeletedFilted(),
            Builders<Trait>.Filter.Eq(x => x.Type, type));

        return await _mongoCollection.Find(filter).ToListAsync();
    }
}
