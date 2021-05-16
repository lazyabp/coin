using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
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