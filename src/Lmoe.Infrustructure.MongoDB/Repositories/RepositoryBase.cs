using Lmoe.Domain.Models.Entities.Base;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public abstract class RepositoryBase<T> where T : DomainEntityBase
{
    protected readonly IMongoCollection<T> _mongoCollection;
    public RepositoryBase(IMongoCollection<T> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    protected FilterDefinition<T> GetIdFilter(Guid id)
    {
        return Builders<T>.Filter.Eq(x => x.Id, id);
    }

    protected FilterDefinition<T> GetNotDeletedFilted()
    {
        return Builders<T>.Filter.Eq(x => x.DeletedAt, null);
    }
}
