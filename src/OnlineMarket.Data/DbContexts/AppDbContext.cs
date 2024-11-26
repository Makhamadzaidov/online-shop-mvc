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
            // Configure precision and scale for decimal properties
            modelBuilder.Entity<Order>()
                .Property(order => order.TotalAmount)
                .HasPrecision(18, 2); // 18 digits in total, 2 after the decimal point

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasPrecision(18, 2);

            // Other configurations...

            modelBuilder.Entity<Category>()
                .HasIndex(category => category.Name)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(customer => new { customer.Phone, customer.Email })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(product => product.Name)
                .IsUnique();

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets", CreatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "Books", Description = "All kinds of books", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "A high-end smartphone",
                    Price = 699.99m,
                    Stock = 50,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Laptop",
                    Description = "A powerful laptop",
                    Price = 999.99m,
                    Stock = 30,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "Fiction Book",
                    Description = "A thrilling fiction novel",
                    Price = 19.99m,
                    Stock = 100,
                    CategoryId = 2,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

    }
}
