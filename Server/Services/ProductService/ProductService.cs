﻿namespace GameShop.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                            .Include(p => p.Category)
                            .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                response.Success = true;
                response.Message = "Product does not exist...";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByCategoryAsync(string categoryUrl)
        {
            try
            {
                var response = new ServiceResponse<List<Product>>()
                {
                    Data = await _context.Products
                    .Where(p => p.Category.Url.ToLower() == categoryUrl)
                    .Include(p => p.Category)
                    .ToListAsync()
                };

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);
            List<string> results = new List<string>();
            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description
                        .Where(char.IsPunctuation)
                        .Distinct()
                        .ToArray();

                    var words = product.Description
                        .Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !results.Contains(word))
                        {
                            results.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>>() { Data = results };
        }

        public async Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await FindProductsBySearchText(searchText)
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            var products = await _context.Products
                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                || p.Description.ToLower().Contains(searchText.ToLower()))
                .Include(p => p.Category)
                .ToListAsync();

            return products;
        }
    }
}
