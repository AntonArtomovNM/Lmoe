using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Models.Entities.Contracts;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class TraitTagRepository : ITraitTagRepository
{
    private readonly IMongoCollection<Weapon> _weaponsCollection;

    public TraitTagRepository(IMongoCollection<Weapon> weaponCollection)
    {
        _weaponsCollection = weaponCollection;
    }

    public async Task DeleteWeaponTraitTag(Guid traitId)
    {
        var filter = GetTraitIdFilter<Weapon>(traitId);
        var update = GetTraitIdUpdate<Weapon>(traitId);

        await _weaponsCollection.UpdateManyAsync(filter, update);
    }

    private FilterDefinition<T> GetTraitIdFilter<T>(Guid traitId)
        where T : ITraitTaggable
    {
        return Builders<T>.Filter.ElemMatch(w => w.Traits, wp => wp.TraitId == traitId);
    }

    private UpdateDefinition<T> GetTraitIdUpdate<T>(Guid traitId)
        where T : ITraitTaggable
    {
        return Builders<T>.Update.PullFilter(w => w.Traits, wp => wp.TraitId == traitId);
    }
}
