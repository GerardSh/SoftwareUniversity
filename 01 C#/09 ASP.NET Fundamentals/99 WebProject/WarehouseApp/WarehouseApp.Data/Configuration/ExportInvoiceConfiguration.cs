using WarehouseApp.Data.Models;
using static WarehouseApp.Common.Constants.EntityConstants.ExportInvoice;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseApp.Data.Configuration
{
    internal class ExportInvoiceConfiguration : IEntityTypeConfiguration<ExportInvoice>
    {
        public void Configure(EntityTypeBuilder<ExportInvoice> entity)
        {
            entity
                .HasKey(ei => ei.Id);

            entity
                .Property(ei => ei.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(InvoiceNumberMaxLength);

            entity
                .Property(ei => ei.ClientId)
                .IsRequired();

            entity
                .HasOne(ei => ei.Client)
                .WithMany(c => c.ExportInvoices)
                .HasForeignKey(ei => ei.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
