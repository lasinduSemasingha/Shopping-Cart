﻿namespace Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }

    }
}
