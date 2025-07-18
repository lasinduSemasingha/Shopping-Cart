namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
