using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(CoinKitBlazorModule)
        )]
    public class CoinKitBlazorServerModule : AbpModule
    {
        
    }
}