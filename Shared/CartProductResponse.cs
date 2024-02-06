namespace GameShop.Shared
{
    public class CartProductResponse
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public int Quantity { get; set; }
    }
}
