using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Shared
{
    public partial class UserButton
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await CartService.GetCartItemsCount();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");
        }
    }
}
