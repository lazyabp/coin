using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.CoinKit.MongoDB
{
    public class CoinKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CoinKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}