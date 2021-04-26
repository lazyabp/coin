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

            var coinActionPermission = myGroup.AddPermission(CoinKitPermissions.CoinAction.Default, L("Permission:CoinAction"));
            coinActionPermission.AddChild(CoinKitPermissions.CoinAction.Create, L("Permission:Create"));
            coinActionPermission.AddChild(CoinKitPermissions.CoinAction.Update, L("Permission:Update"));
            coinActionPermission.AddChild(CoinKitPermissions.CoinAction.Delete, L("Permission:Delete"));

            var coinOrderPermission = myGroup.AddPermission(CoinKitPermissions.CoinOrder.Default, L("Permission:CoinOrder"));
            coinOrderPermission.AddChild(CoinKitPermissions.CoinOrder.Create, L("Permission:Create"));
            coinOrderPermission.AddChild(CoinKitPermissions.CoinOrder.Update, L("Permission:Update"));
            coinOrderPermission.AddChild(CoinKitPermissions.CoinOrder.Delete, L("Permission:Delete"));

            var coinProductPermission = myGroup.AddPermission(CoinKitPermissions.CoinProduct.Default, L("Permission:CoinProduct"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Create, L("Permission:Create"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Update, L("Permission:Update"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Delete, L("Permission:Delete"));

            var coinWalletPermission = myGroup.AddPermission(CoinKitPermissions.CoinWallet.Default, L("Permission:CoinWallet"));
            coinWalletPermission.AddChild(CoinKitPermissions.CoinWallet.Create, L("Permission:Create"));
            coinWalletPermission.AddChild(CoinKitPermissions.CoinWallet.Update, L("Permission:Update"));
            coinWalletPermission.AddChild(CoinKitPermissions.CoinWallet.Delete, L("Permission:Delete"));

            var coinWalletLogPermission = myGroup.AddPermission(CoinKitPermissions.CoinWalletLog.Default, L("Permission:CoinWalletLog"));
            coinWalletLogPermission.AddChild(CoinKitPermissions.CoinWalletLog.Create, L("Permission:Create"));
            coinWalletLogPermission.AddChild(CoinKitPermissions.CoinWalletLog.Update, L("Permission:Update"));
            coinWalletLogPermission.AddChild(CoinKitPermissions.CoinWalletLog.Delete, L("Permission:Delete"));

            var couponPermission = myGroup.AddPermission(CoinKitPermissions.Coupon.Default, L("Permission:Coupon"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Create, L("Permission:Create"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Update, L("Permission:Update"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Delete, L("Permission:Delete"));

            var spreadInvitePermission = myGroup.AddPermission(CoinKitPermissions.SpreadInvite.Default, L("Permission:SpreadInvite"));
            spreadInvitePermission.AddChild(CoinKitPermissions.SpreadInvite.Create, L("Permission:Create"));
            spreadInvitePermission.AddChild(CoinKitPermissions.SpreadInvite.Update, L("Permission:Update"));
            spreadInvitePermission.AddChild(CoinKitPermissions.SpreadInvite.Delete, L("Permission:Delete"));

            var spreadUserPermission = myGroup.AddPermission(CoinKitPermissions.SpreadUser.Default, L("Permission:SpreadUser"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.Create, L("Permission:Create"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.Update, L("Permission:Update"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoinKitResource>(name);
        }
    }
}
