﻿using GameShop.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace GameShop.Client.Pages
{
    public partial class Login
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        private string returnUrl = string.Empty;

        public UserLogin user { get; set; } = new UserLogin();

        public string errorMessage { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url;
            }
        }

        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if (result.Success)
            {
                errorMessage = string.Empty;
                await LocalStorage.SetItemAsync("authToken", result.Data);
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                await CartService.StoreCartItems(true);
                await CartService.GetCartItemsCount();
                NavigationManager.NavigateTo(returnUrl);
            }
            else
            {
                errorMessage = result.Message;
            }
        }
    }
}
