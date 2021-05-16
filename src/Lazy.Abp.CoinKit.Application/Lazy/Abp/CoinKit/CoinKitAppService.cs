using Lazy.Abp.CoinKit.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit
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
