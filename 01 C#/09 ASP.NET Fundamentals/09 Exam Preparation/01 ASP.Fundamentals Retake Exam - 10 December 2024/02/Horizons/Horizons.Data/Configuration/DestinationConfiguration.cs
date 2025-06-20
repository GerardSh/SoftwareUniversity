using Horizons.GCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using static Horizons.GCommon.ValidationConstants.Destination;

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
                .HasMaxLength(DestinationNameMaxLength);

            entity
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(DestinationDescriptionMaxLength);

            entity
                .Property(d => d.ImageUrl)
                .IsRequired(false);

            entity
                .Property(d => d.PublisherId)
                .IsRequired();

            entity
                .HasOne(d => d.Publisher)
                .WithMany() // Navigation collection missing in the build-in IdentityUser
                .HasForeignKey(d => d.PublisherId)
                .IsRequired();

            entity
                .Property(d => d.PublishedOn)
                .IsRequired();

            entity
                .HasOne(d => d.Terrain)
                .WithMany(t => t.Destinations)
                .HasForeignKey(d => d.TerrainId)
                .IsRequired();

            entity
                .Property(d => d.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(d => d.IsDeleted == false);

            entity
                .HasData(GenerateSeedDestinations());
        }

        private List<Destination> GenerateSeedDestinations()
        {
            var destinations = new List<Destination>()
            {

                new Destination
                {
                    Id = 1,
                    Name = "Rila Monastery",
                    Description = "A stunning historical landmark nestled in the Rila Mountains.",
                    ImageUrl = "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg",
                    PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                    PublishedOn = DateTime.Now,
                    TerrainId = 1,
                    IsDeleted = false
                },
                new Destination
                {
                    Id = 2,
                    Name = "Durankulak Beach",
                    Description = "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.",
                    ImageUrl = "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp",
                    PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                    PublishedOn = DateTime.Now,
                    TerrainId = 2,
                    IsDeleted = false
                },
                new Destination
                {
                    Id = 3,
                    Name = "Devil's Throat Cave",
                    Description = "A mysterious cave located in the Rhodope Mountains.",
                    ImageUrl = "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg",
                    PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                    PublishedOn = DateTime.Now,
                    TerrainId = 7,
                    IsDeleted = false
                }
            };

            return destinations;
        }
    }
}
