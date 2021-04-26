using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LazyAbp.CoinKit.MongoDB
{
    public static class CoinKitMongoDbContextExtensions
    {
        public static void ConfigureCoinKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CoinKitMongoModelBuilderConfigurationOptions(
                CoinKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}