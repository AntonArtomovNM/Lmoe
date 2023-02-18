namespace Lmoe.Infrastructure.MongoDB.Settings;

public class MongoDbSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string TraitsCollectionName { get; set; }

    public string WeaponsCollectionName { get; set; }

    public string AmmoPacksCollectionName { get; set; }
}
