﻿namespace GameShop.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;

        Task AddToCart(CartItem item);

        Task<List<CartProductResponse>> GetCartProducts();

        Task RemoveProductFromCart(int productId);

        Task UpdateQuantity(CartProductResponse product);

        Task StoreCartItems(bool emptyLocalCart);

        Task GetCartItemsCount();
    }
}