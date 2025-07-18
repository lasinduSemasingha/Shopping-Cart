using Microsoft.EntityFrameworkCore;
using System.Net;
using Domain.Entities;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(a => a.userId);
                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.Username).IsRequired();
                entity.Property(a => a.PasswordHash).IsRequired();
                entity.Property(a => a.IsActive).IsRequired().HasDefaultValue(true);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(a => a.CartId);
                entity.Property(a => a.IsActive).IsRequired();
                entity.Property(a => a.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(a => a.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); ;
            });
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(a => a.CartItemId);
                entity.Property(a => a.CartId).IsRequired();
                entity.Property(a => a.ProductId).IsRequired();
                entity.Property(a => a.Quantity).IsRequired();
                entity.Property(a => a.ProductTotalPrice).IsRequired().HasColumnType("decimal(18,2)"); ;
                entity.Property(a => a.IsActive).IsRequired().HasDefaultValue(true);

                entity.HasOne(a => a.Cart).WithMany(u => u.CartItems).HasForeignKey(a => a.CartId);

            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(a => a.CategoryId);
                entity.Property(a => a.CategoryName).IsRequired();
                entity.Property(a => a.IsActive).IsRequired().HasDefaultValue(true);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(a => a.ProductId);
                entity.Property(a => a.ProductName).IsRequired();
                entity.Property(a => a.ProductDescription);
                entity.Property(a => a.CategoryId).IsRequired();

                entity.HasOne(a => a.Category).WithMany(u => u.Products).HasForeignKey(a => a.CategoryId);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(a => a.OrderId);
                entity.Property(a => a.CartId).IsRequired();
                entity.Property(a => a.UserId).IsRequired();
                entity.Property(a => a.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); ;

                entity.HasOne(a => a.User).WithMany(u => u.Order).HasForeignKey(a => a.UserId);
                entity.HasOne(a => a.Cart).WithOne(u => u.Order).HasForeignKey<Order>(a => a.CartId);
            });
        }
    }
}
