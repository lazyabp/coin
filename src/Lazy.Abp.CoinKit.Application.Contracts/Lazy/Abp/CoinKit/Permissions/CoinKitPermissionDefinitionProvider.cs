using Lazy.Abp.CoinKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.CoinKit.Permissions
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

            var coinProductPermission = myGroup.AddPermission(CoinKitPermissions.CoinProduct.Default, L("Permission:CoinProduct"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Create, L("Permission:Create"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Update, L("Permission:Update"));
            coinProductPermission.AddChild(CoinKitPermissions.CoinProduct.Delete, L("Permission:Delete"));

            var coinWalletPermission = myGroup.AddPermission(CoinKitPermissions.CoinWallet.Default, L("Permission:CoinWallet"));
            coinWalletPermission.AddChild(CoinKitPermissions.CoinWallet.Management, L("Permission:Management"));
            coinWalletPermission.AddChild(CoinKitPermissions.CoinWallet.Adjustment, L("Permission:Adjustment"));

            var coinWalletLogPermission = myGroup.AddPermission(CoinKitPermissions.CoinWalletLog.Default, L("Permission:CoinWalletLog"));
            coinWalletLogPermission.AddChild(CoinKitPermissions.CoinWalletLog.Management, L("Permission:Management"));

            var couponPermission = myGroup.AddPermission(CoinKitPermissions.Coupon.Default, L("Permission:Coupon"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Create, L("Permission:Create"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Update, L("Permission:Update"));
            couponPermission.AddChild(CoinKitPermissions.Coupon.Delete, L("Permission:Delete"));

            var spreadInvitePermission = myGroup.AddPermission(CoinKitPermissions.SpreadInvite.Default, L("Permission:SpreadInvite"));
            spreadInvitePermission.AddChild(CoinKitPermissions.SpreadInvite.Management, L("Permission:Management"));
            spreadInvitePermission.AddChild(CoinKitPermissions.SpreadInvite.Delete, L("Permission:Delete"));

            var spreadUserPermission = myGroup.AddPermission(CoinKitPermissions.SpreadUser.Default, L("Permission:SpreadUser"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.Management, L("Permission:Management"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.Update, L("Permission:Update"));
            spreadUserPermission.AddChild(CoinKitPermissions.SpreadUser.BindInviter, L("Permission:BindInviter"));

            var coinRechargeHistoryPermission = myGroup.AddPermission(CoinKitPermissions.CoinRechargeHistory.Default, L("Permission:CoinRechargeHistory"));
            coinRechargeHistoryPermission.AddChild(CoinKitPermissions.CoinRechargeHistory.Create, L("Permission:Create"));
            coinRechargeHistoryPermission.AddChild(CoinKitPermissions.CoinRechargeHistory.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoinKitResource>(name);
        }
    }
}
