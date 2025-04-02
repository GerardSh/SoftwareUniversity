using WarehouseApp.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseApp.Data.Configuration
{
    internal class ImportInvoiceDetailConfiguration : IEntityTypeConfiguration<ImportInvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<ImportInvoiceDetail> entity)
        {
            entity
                .HasKey(iid => iid.Id);

            entity
                .HasOne(iid => iid.ImportInvoice)
                .WithMany(ii => ii.ImportInvoicesDetails)
                .HasForeignKey(iid => iid.ImportInvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(iid => iid.Product)
                .WithMany(p => p.ImportInvoicesDetails)
                .HasForeignKey(iid => iid.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(iid => iid.ImportInvoiceId)
                .IsRequired();

            entity
                .Property(iid => iid.ProductId)
                .IsRequired();

            entity
                .Property(iid => iid.Quantity)
                .IsRequired();

            entity
                .Property(iid => iid.UnitPrice)
                .IsRequired(false);
        }
    }
}
