using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GeoTechLog.Data;

/* This is used if database provider does't define
 * IGeoTechLogDbSchemaMigrator implementation.
 */
public class NullGeoTechLogDbSchemaMigrator : IGeoTechLogDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
