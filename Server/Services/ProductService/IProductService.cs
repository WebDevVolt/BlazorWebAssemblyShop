namespace GameShop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductAsync();

        Task<ServiceResponse<Product>> GetProductAsync(int productId);

        Task<ServiceResponse<List<Product>>> GetProductByCategoryAsync(string categoryUrl);

        Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText);

        Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
    }
}
