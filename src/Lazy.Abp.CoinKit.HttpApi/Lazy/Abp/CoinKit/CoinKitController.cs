using Lazy.Abp.CoinKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.CoinKit
{
    public abstract class CoinKitController : AbpController
    {
        protected CoinKitController()
        {
            LocalizationResource = typeof(CoinKitResource);
        }
    }
}
