using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class Cart
    {
        [Inject]
        public ICartService? CartService { get; set; }

        [Inject]
        public IOrderService? OrderService { get; set; }

        public bool OrderPlaced { get; set; } = false;


        List<CartProductResponse>? cartProducts { get; set; }

        string message = "Loading Cart...";

        protected override async Task OnInitializedAsync()
        {
            OrderPlaced = false;
            await LoadCart();
        }

        private async Task RemoveProductFromCart(int productId)
        {
            await CartService.RemoveProductFromCart(productId);
            await LoadCart();
        }

        private async Task LoadCart()
        {
            await CartService.GetCartItemsCount();
            cartProducts = await CartService.GetCartProducts();
            if (cartProducts == null || cartProducts.Count == 0)
            {
                message = "Your cart is empty.";
            }
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse product)
        {
            product.Quantity = int.Parse(e.Value.ToString());
            if (product.Quantity < 1)
                product.Quantity = 1;

            await CartService.UpdateQuantity(product);
        }

        private async Task PlaceOrder()
        {
            await OrderService.PlaceOrder();
            await CartService.GetCartItemsCount();
            OrderPlaced = true;
        }
    }
}
