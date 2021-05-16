using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CoinKit
{
    [DependsOn(
        typeof(CoinKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CoinKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "CoinKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CoinKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
