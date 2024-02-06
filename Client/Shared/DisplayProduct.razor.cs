using GameShop.Client.Shared.Helpers;
using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Shared
{
    public partial class DisplayProduct
    {
        [Parameter]
        public IEnumerable<Product>? Products { get; set; }

        private string GetStyleForPrice(Product? product)
        {
            if (product == null)
                return string.Empty;

            return product.GetStyleForPrice();
        }

    }

}
