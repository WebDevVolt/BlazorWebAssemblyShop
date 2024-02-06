namespace GameShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService LocalStorage;
        private readonly HttpClient _http;

        private readonly AuthenticationStateProvider _authStateProvider;

        public event Action OnChange;


        public CartService(ILocalStorageService localStorage, HttpClient http,
            AuthenticationStateProvider authStateProvider)
        {
            LocalStorage = localStorage;
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task AddToCart(CartItem item)
        {
            if (await IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/cart/add", item);
            }
            else
            {
                var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var sameItem = cart.Find(c => c.ProductId == item.ProductId);
                if (sameItem == null)
                {
                    cart.Add(item);
                }
                else
                {
                    sameItem.Quantity += item.Quantity;
                }

                await LocalStorage.SetItemAsync("cart", cart);
            }

            await GetCartItemsCount();
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            await GetCartItemsCount();
            var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            if (await IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartItems = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                if (cartItems == null)
                    return new List<CartProductResponse>();

                var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
                var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();

                return cartProducts.Data;
            }
        }

        public async Task RemoveProductFromCart(int productId)
        {
            if (await IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/cart/{productId}");
            }
            else
            {
                var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart != null)
                {
                    var cartItem = cart.Find(i => i.ProductId == productId);
                    if (cartItem != null)
                    {
                        cart.Remove(cartItem);
                        await LocalStorage.SetItemAsync("cart", cart);
                    }
                }
            }
        }

        public async Task UpdateQuantity(CartProductResponse product)
        {
            if (await IsUserAuthenticated())
            {
                var request = new CartItem
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                };

                await _http.PutAsJsonAsync("api/cart/update-quantity", request);
            }
            else
            {
                var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart != null)
                {
                    var cartItem = cart.Find(i => i.ProductId == product.ProductId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity = product.Quantity;
                        await LocalStorage.SetItemAsync("cart", cart);
                        OnChange?.Invoke();
                    }
                }
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart == null)
                return;

            await _http.PostAsJsonAsync("api/cart", localCart);
            if (emptyLocalCart)
            {
                await LocalStorage.RemoveItemAsync("cart");
            }
        }

        public async Task GetCartItemsCount()
        {
            if (await IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await LocalStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart");
                await LocalStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }
    }
}
