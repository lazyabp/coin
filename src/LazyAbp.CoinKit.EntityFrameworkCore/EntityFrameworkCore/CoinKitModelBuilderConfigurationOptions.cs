using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.CoinKit.EntityFrameworkCore
{
    public class CoinKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CoinKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}