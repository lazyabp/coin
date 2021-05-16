using Lazy.Abp.CoinKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.CoinKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CoinKitPageModel : AbpPageModel
    {
        protected CoinKitPageModel()
        {
            LocalizationResourceType = typeof(CoinKitResource);
            ObjectMapperContext = typeof(CoinKitWebModule);
        }
    }
}