using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseApp.Data.Models;

namespace WarehouseApp.Data.Configuration
{
    internal class ExportInvoiceDetailConfiguration : IEntityTypeConfiguration<ExportInvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<ExportInvoiceDetail> entity)
        {
            entity
                .HasKey(eid => eid.Id);

            entity
                .HasOne(eid => eid.ExportInvoice)
                .WithMany(ei => ei.ExportInvoicesDetails)
                .HasForeignKey(eid => eid.ExportInvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(eid => eid.ImportInvoiceDetail)
                .WithMany(p => p.ExportInvoicesPerProduct)
                .HasForeignKey(eid => eid.ImportInvoiceDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(eid => eid.ExportInvoiceId)
                .IsRequired();

            entity
                .Property(eid => eid.ImportInvoiceDetailId)
                .IsRequired();

            entity
                .Property(eid => eid.Quantity)
                .IsRequired();

            entity
                .Property(eid => eid.UnitPrice)
                .IsRequired(false);
        }
    }
}
