using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public class AmmoPackRepository : GenericRepository<AmmoPack>, IAmmoPackRepository
{
    public AmmoPackRepository(IMongoCollection<AmmoPack> mongoCollection) : base(mongoCollection)
    {
    }
}
