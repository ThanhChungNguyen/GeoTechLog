using GeoTechLog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GeoTechLog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class GeoTechLogController : AbpControllerBase
{
    protected GeoTechLogController()
    {
        LocalizationResource = typeof(GeoTechLogResource);
    }
}
