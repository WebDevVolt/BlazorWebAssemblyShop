using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public string CategoryUrl { get; set; } = string.Empty;

        [Parameter]
        public string? SearchText { get; set; } = null;

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                await ProductService.GetProducts(CategoryUrl);
            }
            else
            {
                await ProductService.SearchProducts(SearchText);
            }
        }
    }
}
