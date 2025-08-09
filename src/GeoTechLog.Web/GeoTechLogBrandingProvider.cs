using Microsoft.Extensions.Localization;
using GeoTechLog.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace GeoTechLog.Web;

[Dependency(ReplaceServices = true)]
public class GeoTechLogBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<GeoTechLogResource> _localizer;

    public GeoTechLogBrandingProvider(IStringLocalizer<GeoTechLogResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
