using Localization.Resources.AbpUi;
using LazyAbp.CoinKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LazyAbp.CoinKit
{
    [DependsOn(
        typeof(CoinKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CoinKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CoinKitHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CoinKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
