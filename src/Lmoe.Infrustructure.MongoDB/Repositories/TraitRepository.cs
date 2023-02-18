using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class TraitRepository : GenericRepository<Trait>, ITraitRepository
{
    public TraitRepository(IMongoCollection<Trait> mongoCollection)
        : base(mongoCollection)
    {
    }

    public async Task<ICollection<Trait>> GetAll(TraitType type)
    {
        var filter = _filterBuilder.And(
            GetNotDeletedFilted(),
            _filterBuilder.Eq(x => x.Type, type));

        return await _mongoCollection.Find(filter).ToListAsync();
    }
}
