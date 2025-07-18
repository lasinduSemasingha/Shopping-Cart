namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public Cart Cart { get; set; }
        public User User { get; set; }
    }
}
