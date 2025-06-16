using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Horizons.Data.Models;

namespace Horizons.Data.Configuration
{
    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> entity)
        {
            entity
                .HasKey(ud => new { ud.UserId, ud.DestinationId });

            entity
                .HasOne(ud => ud.User)
                .WithMany() // Navigation collection missing in the build-in IdentityUser
                .HasForeignKey(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasQueryFilter(ud => !ud.Destination.IsDeleted);
        }
    }
}
