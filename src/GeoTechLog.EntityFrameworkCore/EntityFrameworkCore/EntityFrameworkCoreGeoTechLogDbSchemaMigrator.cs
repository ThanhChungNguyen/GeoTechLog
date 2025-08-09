using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GeoTechLog.Data;
using Volo.Abp.DependencyInjection;

namespace GeoTechLog.EntityFrameworkCore;

public class EntityFrameworkCoreGeoTechLogDbSchemaMigrator
    : IGeoTechLogDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreGeoTechLogDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the GeoTechLogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<GeoTechLogDbContext>()
            .Database
            .MigrateAsync();
    }
}
