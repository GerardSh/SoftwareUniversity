using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShoppingListApp.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }

        //Here the information is seeded upon startup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                     new Product() { Id = 1, Name = "Cheese" },
                     new Product() { Id = 2, Name = "Milk" });

            base.OnModelCreating(modelBuilder);
        }
    }
}