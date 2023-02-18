using Lmoe.Domain.Models.Entities;
using Lmoe.Domain.Repositories;
using Lmoe.Infrastructure.MongoDB.Extensions;
using Lmoe.Infrastructure.MongoDB.Repositories;
using Lmoe.Infrastructure.MongoDB.Settings;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SimpleInjector;

namespace Lmoe.Infrastructure.MongoDB;

public static class IoC
{
    public static void RegisterMongoDb(this Container container, MongoDbSettings settings)
    {
        var mongoClient = new MongoClient(settings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);

        // Register collections
        var traitsCollection = mongoDatabase.ConfigureCollection<Trait>(
            settings.TraitsCollectionName, 
            keyBuilder => keyBuilder
                .Ascending(t => t.Type)
                .Ascending(t => t.Name));

        var weaponsCollection = mongoDatabase.ConfigureCollection<Weapon>(
            settings.WeaponsCollectionName,
            keyBuilder => keyBuilder
                .Ascending(w => w.Type)
                .Ascending(w => w.Name)
                .Ascending(w => w.IsRare));

        var ammoPacksCollection = mongoDatabase.ConfigureCollection<AmmoPack>(
            settings.AmmoPacksCollectionName,
            keyBuilder => keyBuilder
                .Ascending(ap => ap.AmmoType)
                .Ascending(ap => ap.Name)
                .Ascending(ap => ap.IsRare));

        container.RegisterInstance(traitsCollection);
        container.RegisterInstance(weaponsCollection);
        container.RegisterInstance(ammoPacksCollection);

        // Register repositories
        container.Register<ITraitRepository, TraitRepository>(Lifestyle.Scoped);
        container.Register<IWeaponRepository, WeaponRepository>(Lifestyle.Scoped);
        container.Register<IAmmoPackRepository, AmmoPackRepository>(Lifestyle.Scoped);

        // Register conventions
        ConventionRegistry.Register("IgnoreIfNullConvention", new ConventionPack { new IgnoreIfNullConvention(true) }, _ => true);
    }
}
