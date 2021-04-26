using LazyAbp.CoinKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CoinKitEntityFrameworkCoreTestModule)
        )]
    public class CoinKitDomainTestModule : AbpModule
    {
        
    }
}
