namespace Lazy.Abp.CoinKit
{
    public static class CoinKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "CoinKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CoinKit";
    }
}
