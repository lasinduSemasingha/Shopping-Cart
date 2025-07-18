namespace Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public bool? IsActive { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public Order Order { get; set; }
    }
}
