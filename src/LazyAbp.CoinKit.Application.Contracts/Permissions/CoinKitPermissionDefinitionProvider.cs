using LazyAbp.CoinKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.CoinKit.Permissions
{
    public class CoinKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CoinKitPermissions.GroupName, L("Permission:CoinKit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoinKitResource>(name);
        }
    }
}