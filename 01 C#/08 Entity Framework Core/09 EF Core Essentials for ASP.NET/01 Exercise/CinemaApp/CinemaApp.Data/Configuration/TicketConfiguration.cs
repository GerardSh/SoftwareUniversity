using CinemaApp.Data.Models;
using CinemaApp.Common.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{

    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            // Define the primary key of the Ticket entity
            entity
                .HasKey(t => t.Id);

            // Define constraints for the Price column
            entity
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnType(EntityConstants.MoneyType);

            // Define constraints for the CinemaMovieId column
            entity
                .Property(t => t.CinemaMovieId)
                .IsRequired();

            // Define constraints for the ApplicationUserId column
            entity
                .Property(t => t.ApplicationUserId)
                .IsRequired();

            // Define relation between the Ticket and CinemaMovie entities
            entity
                .HasOne(t => t.CinemaMovie)
                .WithMany(cm => cm.Tickets)
                .HasForeignKey(t => t.CinemaMovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define relation between the Ticket and ApplicationUser entities
            entity
                .HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Tickets)
                .HasForeignKey(t => t.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
