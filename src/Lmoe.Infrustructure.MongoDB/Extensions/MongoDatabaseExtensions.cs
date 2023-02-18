using Lmoe.Domain.Models.Entities.Base;
using MongoDB.Driver;

namespace Lmoe.Infrastructure.MongoDB.Extensions;

public static class MongoDatabaseExtensions
{
    private const int ExpireRecordsAfterDays = 30;

    public static IMongoCollection<T> ConfigureCollection<T>(this IMongoDatabase mongoDatabase, string collectionName, Func<IndexKeysDefinitionBuilder<T>, IndexKeysDefinition<T>> lookupIndexFunc)
        where T : BaseDomainEntity
    {
        var collection = mongoDatabase.GetCollection<T>(collectionName);

        var lookupIndex = lookupIndexFunc.Invoke(Builders<T>.IndexKeys);
        var lookupOptions = new CreateIndexOptions<T>
        {
            Name = $"{collectionName}_lookup",
            PartialFilterExpression = Builders<T>.Filter.Eq(x => x.DeletedAt, null),
        };

        collection.Indexes.CreateOne(new CreateIndexModel<T>(lookupIndex, lookupOptions));

        var ttlIndex = Builders<T>.IndexKeys.Ascending(x => x.DeletedAt);
        var ttlOptions = new CreateIndexOptions<T>
        {
            Name = $"{collectionName}_ttl",
            ExpireAfter = TimeSpan.FromDays(ExpireRecordsAfterDays),
        };

        collection.Indexes.CreateOne(new CreateIndexModel<T>(ttlIndex, ttlOptions));

        return collection;
    }
}
