using WarehouseApp.Data.Models;
using static WarehouseApp.Common.Constants.EntityConstants.Client;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseApp.Data.Configuration
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity
                .HasKey(c => c.Id);

            entity
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            entity
                .Property(c => c.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(PhoneNumberMaxLength);

            entity
                .Property(c => c.Email)
                .IsRequired(false)
                .HasMaxLength(EmailMaxLength);
        }
    }
}
