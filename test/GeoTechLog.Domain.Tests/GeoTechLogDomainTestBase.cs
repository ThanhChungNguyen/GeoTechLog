using Volo.Abp.Modularity;

namespace GeoTechLog;

/* Inherit from this class for your domain layer tests. */
public abstract class GeoTechLogDomainTestBase<TStartupModule> : GeoTechLogTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
