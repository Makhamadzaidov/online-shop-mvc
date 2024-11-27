using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Order>()
                .Property(order => order.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>()
                .HasIndex(category => category.Name)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(customer => new { customer.PhoneNumber, customer.Email })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(product => product.Name)
                .IsUnique();
        }

    }
}
