using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Lazy.Abp.CoinKit
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
