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
    }
}