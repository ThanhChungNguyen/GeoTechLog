using GeoTechLog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace GeoTechLog.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GeoTechLogEntityFrameworkCoreModule),
    typeof(GeoTechLogApplicationContractsModule)
    )]
public class GeoTechLogDbMigratorModule : AbpModule
{
}
