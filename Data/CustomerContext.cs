using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new { p.ProductId, p.OrderId });

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(pc => pc.Product)
                        .WithMany(p => p.OrderProducts)
                        .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(pc => pc.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(p => p.OrderId);

        }
    }
}
