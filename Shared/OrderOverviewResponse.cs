namespace GameShop.Shared
{
    public class OrderOverviewResponse
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }

        public string Prodcut { get; set; } = string.Empty;

        public string ProductImageUrl { get; set; } = string.Empty;
    }
}
