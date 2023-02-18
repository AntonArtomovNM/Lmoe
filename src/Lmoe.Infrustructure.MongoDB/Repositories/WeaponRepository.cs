using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class WeaponRepository : GenericRepository<Weapon>, IWeaponRepository
{
    public WeaponRepository(IMongoCollection<Weapon> mongoCollection)
        : base(mongoCollection)
    {
    }

    public async Task RemoveTraitTag(Guid traitId)
    {
        var filter = Builders<Weapon>.Filter.ElemMatch(w => w.Traits, wp => wp.TraitId == traitId);
        var update = Builders<Weapon>.Update.PullFilter(w => w.Traits, wp => wp.TraitId == traitId);

        await _mongoCollection.UpdateManyAsync(filter, update);
    }
}
