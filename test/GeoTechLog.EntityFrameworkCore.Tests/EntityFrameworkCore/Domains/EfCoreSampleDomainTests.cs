using GeoTechLog.Samples;
using Xunit;

namespace GeoTechLog.EntityFrameworkCore.Domains;

[Collection(GeoTechLogTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<GeoTechLogEntityFrameworkCoreTestModule>
{

}
