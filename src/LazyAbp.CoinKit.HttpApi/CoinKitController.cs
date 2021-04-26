using LazyAbp.CoinKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.CoinKit
{
    public abstract class CoinKitController : AbpController
    {
        protected CoinKitController()
        {
            LocalizationResource = typeof(CoinKitResource);
        }
    }
}
