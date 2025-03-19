using CinemaApp.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Data.Configuration
{
    // Added for later usage
    // Currently not needed, since we are not aware of the Identity system
    public static class DatabaseSeeder
    {
        public static void SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            string[] roles = { "Admin", "Manager", "User" };

            foreach (var role in roles)
            {
                var roleExists = roleManager.RoleExistsAsync(role).GetAwaiter().GetResult();
                if (!roleExists)
                {
                    var result = roleManager.CreateAsync(new IdentityRole<Guid>(role)).GetAwaiter().GetResult();
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create role: {role}");
                    }
                }
            }
        }

        public static void AssignAdminRole(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            SeedUser(userManager, "admin@example.com", "Admin@123", "Admin");
            SeedUser(userManager, "appManager@example.com", "123asd", "Manager");
            SeedUser(userManager, "appUser@example.com", "123asd", "User");
        }

        private static void SeedUser(UserManager<ApplicationUser> userManager, string email, string password, string role)
        {
            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email
                };
                var createUserResult = userManager.CreateAsync(user, password).GetAwaiter().GetResult();
                if (!createUserResult.Succeeded)
                {
                    throw new Exception($"Failed to create user: {email}");
                }
            }

            var isInRole = userManager.IsInRoleAsync(user, role).GetAwaiter().GetResult();
            if (!isInRole)
            {
                var addRoleResult = userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
                if (!addRoleResult.Succeeded)
                {
                    throw new Exception($"Failed to assign {role} role to user: {email}");
                }
            }
        }
    }
}
