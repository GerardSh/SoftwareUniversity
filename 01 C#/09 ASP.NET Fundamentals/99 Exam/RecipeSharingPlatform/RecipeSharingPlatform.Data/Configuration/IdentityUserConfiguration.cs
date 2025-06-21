using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RecipeSharingPlatform.Data.Configuration
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> entity)
        {
            entity
                .HasData(CreateDefaultAdminUser());
        }

        private IdentityUser CreateDefaultAdminUser()
        {
            var defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@recipesharing.com",
                NormalizedUserName = "ADMIN@RECIPESHARING.COM",
                Email = "admin@recipesharing.com",
                NormalizedEmail = "ADMIN@RECIPESHARING.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@recipesharing.com" },
                    "Admin123!")
            };

            return defaultUser;
        }
    }
}
