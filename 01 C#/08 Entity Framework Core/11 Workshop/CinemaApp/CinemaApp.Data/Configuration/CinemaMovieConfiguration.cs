using CinemaApp.Data.Models;
using static CinemaApp.Common.Constants.EntityConstants.CinemaMovie;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    internal class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> entity)
        {
            // Define the primary key of the CinemaMovie entity
            entity
                .HasKey(cm => cm.Id);

            // Define constraints for MovieId column
            entity
                .Property(cm => cm.MovieId)
                .IsRequired();

            // Define constraints for CinemaId column
            entity
                .Property(cm => cm.CinemaId)
                .IsRequired();

            // Define constraints for AvailableTickets column
            entity
                .Property(cm => cm.AvailableTickets)
                .IsRequired();

            // Define constraints for IsDeleted column
            entity
                .Property(cm => cm.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Define constraints for Showtimes column
            entity
                .Property(cm => cm.Showtimes)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(ShowtimesMaxLength)
                .HasDefaultValue(ShowtimesDefaultFormat);

            // Define relation between the CinemaMovie and Movie entities
            entity
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.MovieCinemas)
                .HasForeignKey(cm => cm.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define relation between the CinemaMovie and Cinema entities
            entity
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define unique index as a combination of the foreign keys to Cinema and Movie entities
            entity
                .HasIndex(cm => new { cm.CinemaId, cm.MovieId })
                .IsUnique();

            // Ensure that only existing records are used in the business logic
            entity
                .HasQueryFilter(cm => cm.IsDeleted == false);
        }
    }
}
