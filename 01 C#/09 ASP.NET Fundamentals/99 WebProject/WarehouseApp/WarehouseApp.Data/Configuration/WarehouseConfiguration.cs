using WarehouseApp.Data.Models;
using static WarehouseApp.Common.Constants.EntityConstants.Warehouse;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseApp.Data.Configuration
{
    internal class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity
                .HasKey(w => w.Id);

            entity
                .Property(w => w.Size)
                .IsRequired(false);

            entity
                .Property(w => w.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);
        }
    }
}
