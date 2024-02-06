namespace GameShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products...";

        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            try
            {
                var result = categoryUrl == null
               ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product")
               : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
                if (result != null && result.Data != null)
                    Products = result.Data;

                ProductsChanged.Invoke();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            if (Products.Count == 0)
                Message = "No Products Found.";

            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/suggestions/{searchText}");
            return result.Data;
        }
    }
}
