namespace Domain.Entities
{
    public class User
    {
        public int userId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
