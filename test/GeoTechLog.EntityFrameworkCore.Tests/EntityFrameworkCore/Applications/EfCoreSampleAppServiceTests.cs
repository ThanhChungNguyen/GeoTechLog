using GeoTechLog.Samples;
using Xunit;

namespace GeoTechLog.EntityFrameworkCore.Applications;

[Collection(GeoTechLogTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<GeoTechLogEntityFrameworkCoreTestModule>
{

}
