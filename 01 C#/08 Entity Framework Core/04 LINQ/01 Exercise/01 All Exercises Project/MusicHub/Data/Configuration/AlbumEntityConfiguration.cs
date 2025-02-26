using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    using static EntityValidationConstants.Album;
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity
                .HasKey(a => a.Id);

            entity
                .Property(a => a.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(AlbumNameMaxLength);

            entity
                .Property(a => a.ReleaseDate)
                .IsRequired();

            entity
                .Property(a => a.ProducerId)
                .IsRequired(false);

            entity
                .HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);
        }
    }
}
