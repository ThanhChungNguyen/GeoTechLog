using System;
using System.Collections.Generic;
using System.Text;
using GeoTechLog.Localization;
using Volo.Abp.Application.Services;

namespace GeoTechLog;

/* Inherit your application services from this class.
 */
public abstract class GeoTechLogAppService : ApplicationService
{
    protected GeoTechLogAppService()
    {
        LocalizationResource = typeof(GeoTechLogResource);
    }
}
