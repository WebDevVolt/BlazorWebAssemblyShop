﻿namespace GameShop.Shared
{
    public class CartItem
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
