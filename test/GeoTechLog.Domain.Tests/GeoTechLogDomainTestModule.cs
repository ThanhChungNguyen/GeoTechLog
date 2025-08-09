using Volo.Abp.Modularity;

namespace GeoTechLog;

[DependsOn(
    typeof(GeoTechLogDomainModule),
    typeof(GeoTechLogTestBaseModule)
)]
public class GeoTechLogDomainTestModule : AbpModule
{

}
