using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CoinKitDomainSharedModule)
    )]
    public class CoinKitDomainModule : AbpModule
    {

    }
}
