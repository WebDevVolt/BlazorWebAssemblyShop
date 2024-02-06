using GameShop.Client.Shared.Helpers;

namespace GameShop.Client.Shared
{
    public partial class GameShopNavMenu
    {
        private string GetIconForCategory(string categoryName)
        {
            return categoryName.GetIconForCategory();
        }
    }
}
