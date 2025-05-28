using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext
            (DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Cheese",
                    Description = "From sheep milk"
                },
                new Product
                {
                    Id = 2,
                    Name = "Orange juice",
                    Description = "Fresh, from our best fruits"
                },
                new Product
                {
                    Id = 3,
                    Name = "Apple",
                    Description = "Type: red delicious"
                }
            );
        }
    }
}
