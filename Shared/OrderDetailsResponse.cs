namespace GameShop.Shared
{
    public class OrderDetailsResponse
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }

        public List<OrderDetailsProductResponse> Products { get; set; }
    }
}
