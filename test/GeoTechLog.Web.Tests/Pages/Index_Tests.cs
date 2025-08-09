using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace GeoTechLog.Pages;

public class Index_Tests : GeoTechLogWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
