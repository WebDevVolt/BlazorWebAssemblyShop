using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Shared
{
    public partial class ProductList : IDisposable
    {
        [Inject]
        public IProductService? ProductService { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            ProductService.ProductsChanged += StateHasChanged;
        }

        protected IOrderedEnumerable<IGrouping<int?, Product>> GetGroupedProductByCategory()
        {
            return from product in ProductService.Products
                   group product by product?.Category?.Id into prodByCategory
                   orderby prodByCategory.Key
                   select prodByCategory;
        }


        protected string GetCategoryName(IGrouping<int?, Product> groupedProduct)
        {
            return groupedProduct.FirstOrDefault(pg => pg.Category.Id == groupedProduct.Key).Category?.Name;
        }

        void IDisposable.Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }

        private void ViewMore(Product? product)
        {
            NavigationManager.NavigateTo($"{product?.Category?.Url}");
        }
    }
}
