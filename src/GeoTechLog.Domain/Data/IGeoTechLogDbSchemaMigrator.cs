using System.Threading.Tasks;

namespace GeoTechLog.Data;

public interface IGeoTechLogDbSchemaMigrator
{
    Task MigrateAsync();
}
