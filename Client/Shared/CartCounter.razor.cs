using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Shared
{
    public partial class CartCounter : IDisposable
    {
        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public ISyncLocalStorageService LocalStoareg { get; set; }

        private int GetCartItemCount()
        {
            var count = LocalStoareg.GetItem<int>("cartItemsCount");
            return count;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        void IDisposable.Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
    }
}
