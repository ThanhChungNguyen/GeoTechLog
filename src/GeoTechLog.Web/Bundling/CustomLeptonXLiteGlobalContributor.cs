using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace GeoTechLog.Web.Bundling
{
    public class CustomLeptonXLiteGlobalContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.RemoveAll(f => f.FileName.Contains("/libs/abp/utils/abp-utils.umd.min.js"));

            context.Files.Add("/libs/abp/core/abp.js"); 
        }
    }
}
