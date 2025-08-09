using Microsoft.AspNetCore.Builder;
using GeoTechLog;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("GeoTechLog.Web.csproj");
await builder.RunAbpModuleAsync<GeoTechLogWebTestModule>(applicationName: "GeoTechLog.Web" );

public partial class Program
{
}
