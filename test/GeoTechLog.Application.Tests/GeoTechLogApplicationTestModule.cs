using Volo.Abp.Modularity;

namespace GeoTechLog;

[DependsOn(
    typeof(GeoTechLogApplicationModule),
    typeof(GeoTechLogDomainTestModule)
)]
public class GeoTechLogApplicationTestModule : AbpModule
{

}
