using Volo.Abp.Modularity;

namespace GeoTechLog;

public abstract class GeoTechLogApplicationTestBase<TStartupModule> : GeoTechLogTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
