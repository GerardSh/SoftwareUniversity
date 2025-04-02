using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WarehouseApp.Data.Models;

namespace WarehouseApp.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {
        }

        public WarehouseDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ImportInvoice> ImportInvoices { get; set; }

        public DbSet<ImportInvoiceDetail> ImportInvoiceDetails { get; set; }

        public DbSet<ExportInvoice> ExportInvoices { get; set; }

        public DbSet<ExportInvoiceDetail> ExportInvoiceDetails { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
