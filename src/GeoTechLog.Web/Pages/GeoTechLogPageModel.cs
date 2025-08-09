using GeoTechLog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace GeoTechLog.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class GeoTechLogPageModel : AbpPageModel
{
    protected GeoTechLogPageModel()
    {
        LocalizationResourceType = typeof(GeoTechLogResource);
    }
}
