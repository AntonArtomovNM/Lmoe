using Lmoe.Host.Enums;
using Lmoe.Host.Settings;
using Lmoe.Infrastructure.MongoDB;
using SimpleInjector;

namespace Lmoe.Host;

public static class IoC
{
    public static void Initialize(this Container container, IConfiguration configuration)
    {
        RegisterDb(container, configuration);
    }

    private static void RegisterDb(Container container, IConfiguration configuration)
    {
        var dbSettings = configuration.GetSection(DbSettings.SectionKey).Get<DbSettings>();
        var dbStorage = dbSettings.DbStorage;

        switch (dbStorage)
        {
            case DbStorage.MongoDb:
                container.RegisterMongoDb(dbSettings.MongoDbSettings);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(dbStorage), dbStorage, "Specified storage is not supported");
        }
    }
}