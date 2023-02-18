using Lmoe.Host.Enums;
using Lmoe.Infrastructure.MongoDB.Settings;

namespace Lmoe.Host.Settings;

public class DbSettings
{
    public const string SectionKey = "DbSettings";

    public DbStorage DbStorage { get; set; }

    public MongoDbSettings MongoDbSettings { get; set; }
}
