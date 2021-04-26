using Volo.Abp.Reflection;

namespace LazyAbp.CoinKit.Permissions
{
    public class CoinKitPermissions
    {
        public const string GroupName = "CoinKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CoinKitPermissions));
        }

        public class CoinAction
        {
            public const string Default = GroupName + ".CoinAction";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CoinOrder
        {
            public const string Default = GroupName + ".CoinOrder";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CoinProduct
        {
            public const string Default = GroupName + ".CoinProduct";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CoinWallet
        {
            public const string Default = GroupName + ".CoinWallet";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CoinWalletLog
        {
            public const string Default = GroupName + ".CoinWalletLog";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Coupon
        {
            public const string Default = GroupName + ".Coupon";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class SpreadInvite
        {
            public const string Default = GroupName + ".SpreadInvite";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class SpreadUser
        {
            public const string Default = GroupName + ".SpreadUser";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
