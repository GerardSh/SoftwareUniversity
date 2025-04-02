using WarehouseApp.Data.Models;
using static WarehouseApp.Common.Constants.EntityConstants.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseApp.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(ProductNameMaxLength);

            entity
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);
        }
    }
}
