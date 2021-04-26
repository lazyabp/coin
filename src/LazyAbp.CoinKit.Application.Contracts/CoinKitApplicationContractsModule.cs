using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LazyAbp.CoinKit
{
    [DependsOn(
        typeof(CoinKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CoinKitApplicationContractsModule : AbpModule
    {

    }
}
