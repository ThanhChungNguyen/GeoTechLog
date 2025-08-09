using Volo.Abp.Settings;

namespace GeoTechLog.Settings;

public class GeoTechLogSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(GeoTechLogSettings.MySetting1));
    }
}
