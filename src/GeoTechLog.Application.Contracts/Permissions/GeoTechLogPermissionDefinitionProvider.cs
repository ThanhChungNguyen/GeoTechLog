using GeoTechLog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GeoTechLog.Permissions;

public class GeoTechLogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GeoTechLogPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(GeoTechLogPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GeoTechLogResource>(name);
    }
}
