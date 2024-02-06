using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Shared
{
    public partial class Search
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        private string searchText = string.Empty;

        private List<string> suggestions = new List<string>();

        protected ElementReference searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }

        public void SearchProducts()
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if (args.Key == null || args.Key.Equals("Enter"))
            {
                SearchProducts();
            }
            else if (searchText.Length > 3)
            {
                suggestions = await ProductService.GetProductSuggestions(searchText);
            }
        }
    }
}
