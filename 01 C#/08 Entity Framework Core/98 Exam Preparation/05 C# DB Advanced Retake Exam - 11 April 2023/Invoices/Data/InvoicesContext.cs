using Invoices.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Invoices.Data
{
    public class InvoicesContext : DbContext
    {
        public InvoicesContext() 
        { 
        }

        public InvoicesContext(DbContextOptions options)
            : base(options)
        { 
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Address> Addresses { get; set; } = null!;

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;

        public virtual DbSet<Client> Clients { get; set; } = null!;

        public virtual DbSet<ProductClient> ProductsClients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductClient>().HasKey(e => new { e.ProductId, e.ClientId });
        }
    }
}
