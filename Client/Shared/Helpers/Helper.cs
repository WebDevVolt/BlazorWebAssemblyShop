namespace GameShop.Client.Shared.Helpers
{
    public static class Helper
    {
        public static string GetStyleForPrice(this Product product)
        {
            if (product != null)
            {
                if (product.SalePrice > 0)
                {
                    return "price";
                }
            }

            return "salePrice";
        }

        public static string GetIconForCategory(this string categoryName)
        {
            switch (categoryName.ToLower())
            {
                case "playstation": return "bi bi-playstation fs-2";
                case "xbox": return "bi bi-xbox fs-2";
                case "pc": return "bi bi-laptop-fill fs-2";
                default:
                    return string.Empty;
            }
        }
    }
}
