using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit.Blazor.WebAssembly
{
    [DependsOn(
        typeof(CoinKitBlazorModule),
        typeof(CoinKitHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class CoinKitBlazorWebAssemblyModule : AbpModule
    {
        
    }
}