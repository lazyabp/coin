using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CoinKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CoinKitDomainSharedModule)
    )]
    public class CoinKitDomainModule : AbpModule
    {

    }
}
