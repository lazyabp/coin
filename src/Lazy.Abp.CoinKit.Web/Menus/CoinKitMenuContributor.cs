using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.CoinKit.Web.Menus
{
    public class CoinKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(CoinKitMenus.Prefix, displayName: "CoinKit", "~/CoinKit", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}