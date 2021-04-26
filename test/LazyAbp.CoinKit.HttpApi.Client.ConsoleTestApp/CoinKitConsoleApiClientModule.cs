using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit
{
    [DependsOn(
        typeof(CoinKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CoinKitConsoleApiClientModule : AbpModule
    {
        
    }
}
