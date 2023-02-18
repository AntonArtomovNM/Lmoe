using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Domain.Repositories;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Repositories;

public abstract class GenericRepository<T> : IRepository<T>
    where T : BaseDomainEntity
{
    protected readonly IMongoCollection<T> _mongoCollection;
    protected readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public GenericRepository(IMongoCollection<T> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task<T> Create(T entity)
    {
        await _mongoCollection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<T> Update(T entity)
    {
        await _mongoCollection.ReplaceOneAsync(GetIdFilter(entity.Id), entity);

        return entity;
    }

    public async Task<T> GetById(Guid id)
    {
        return await _mongoCollection.Find(GetIdFilter(id)).FirstOrDefaultAsync();
    }

    public async Task<ICollection<T>> GetAll()
    {
        return await _mongoCollection.Find(GetNotDeletedFilted()).ToListAsync();
    }

    protected FilterDefinition<T> GetNotDeletedFilted()
    {
        return _filterBuilder.Eq(x => x.DeletedAt, null);
    }

    private FilterDefinition<T> GetIdFilter(Guid id)
    {
        return _filterBuilder.Eq(x => x.Id, id);
    }
}
