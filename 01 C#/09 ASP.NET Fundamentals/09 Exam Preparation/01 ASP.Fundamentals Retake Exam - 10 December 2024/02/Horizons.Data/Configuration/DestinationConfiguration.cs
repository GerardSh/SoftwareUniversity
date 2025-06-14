using Horizons.GCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using static Horizons.GCommon.ValidationConstants;

namespace Horizons.Data.Configuration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> entity)
        {
            entity
                .HasKey(d => d.Id);

            entity
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(d => d.ImageUrl)
                .IsRequired(false);

            entity
                .Property(d => d.PublisherId)
                .IsRequired();

            //entity
            //    .HasOne(d => d.Publisher)
            //    .WithMany()
            //    .HasForeignKey(d => d.PublisherId)
            //    .IsRequired();

            //entity
            //    .Property(d => d.PublishedOn)
            //    .IsRequired();

            //entity
            //    .HasOne(d => d.Terrain)
            //    .WithMany()
            //    .HasForeignKey(d => d.TerrainId)
            //    .IsRequired();

            entity
                .Property(d => d.IsDeleted)
                .HasDefaultValue(false);


            //entity
            //    .HasMany(d => d.UsersDestinations)
            //    .WithOne()
            //    .HasForeignKey("DestinationId");

            entity
                .HasQueryFilter(d => d.IsDeleted == false);
        }
    }
}
