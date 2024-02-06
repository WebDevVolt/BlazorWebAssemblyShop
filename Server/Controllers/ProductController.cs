
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productService.GetProductAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _productService.GetProductAsync(productId);
            return Ok(product);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<Product>> GetProductByCategory(string categoryUrl)
        {
            var products = await _productService.GetProductByCategoryAsync(categoryUrl);
            return Ok(products);
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<Product>> SearchProducts(string searchText)
        {
            var products = await _productService.SearchProductsAsync(searchText);
            return Ok(products);
        }

        [HttpGet("suggestions/{searchText}")]
        public async Task<ActionResult<Product>> GetProductSearchSuggestions(string searchText)
        {
            var products = await _productService.GetProductSearchSuggestionsAsync(searchText);
            return Ok(products);
        }
    }
}
