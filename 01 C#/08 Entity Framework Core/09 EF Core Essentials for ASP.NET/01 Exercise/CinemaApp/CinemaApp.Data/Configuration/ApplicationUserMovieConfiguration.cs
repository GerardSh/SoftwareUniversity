using CinemaApp.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> entity)
        {
            // Define the composite primary key of entity
            entity
                .HasKey(aum => new { aum.ApplicationUserId, aum.MovieId });

            // Set default value of IsDeleted property
            entity
                .Property(aum => aum.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Define the relation between ApplicationUserMovie and ApplicationUser
            entity
                .HasOne(aum => aum.ApplicationUser)
                .WithMany(au => au.Watchlist)
                .HasForeignKey(aum => aum.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define the relation between ApplicationUserMovie and Movie
            // DeleteBehavior.NoAction is chose, because we support Soft Delete for Movies
            entity
                .HasOne(aum => aum.Movie)
                .WithMany(m => m.MovieApplicationUsers)
                .HasForeignKey(aum => aum.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ensure that only existing records are used in the business logic
            entity
                .HasQueryFilter(aum => aum.IsDeleted == false);
        }
    }
}
