using Xunit;

namespace GeoTechLog.EntityFrameworkCore;

[CollectionDefinition(GeoTechLogTestConsts.CollectionDefinitionName)]
public class GeoTechLogEntityFrameworkCoreCollection : ICollectionFixture<GeoTechLogEntityFrameworkCoreFixture>
{

}
