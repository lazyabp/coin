using LazyAbp.CoinKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit
{
    public abstract class CoinKitAppService : ApplicationService
    {
        protected CoinKitAppService()
        {
            LocalizationResource = typeof(CoinKitResource);
            ObjectMapperContext = typeof(CoinKitApplicationModule);
        }
    }
}
