using GameShop.Client.Shared.Helpers;
using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class ProductDetails
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private Product? product = null;

        private string message = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading Product...";
            var result = await ProductService.GetProduct(Id);
            if (!result.Success)
            {
                message = result.Message;
            }
            else
            {
                product = result.Data;
            }
        }

        private string GetStyleForPrice(Product? product)
        {
            if (product == null)
                return string.Empty;

            return product.GetStyleForPrice();
        }

        private async Task AddToCart(int productId)
        {
            var cartIem = new CartItem { ProductId = productId };
            await CartService.AddToCart(cartIem);

        }
    }
}
