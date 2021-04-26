using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit
{
    [DependsOn(
        typeof(CoinKitApplicationModule),
        typeof(CoinKitDomainTestModule)
        )]
    public class CoinKitApplicationTestModule : AbpModule
    {

    }
}
