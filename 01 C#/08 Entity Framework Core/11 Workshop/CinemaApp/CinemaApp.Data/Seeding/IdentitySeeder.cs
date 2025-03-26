using CinemaApp.Data.Models;
using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities.Interfaces;
using static CinemaApp.Common.OutputMessages.ErrorMessages;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding
{
    public class IdentitySeeder : BaseSeeder<IdentitySeeder>, IEntitySeeder, 
        IIdentitySeeder<ApplicationUser, IdentityRole<Guid>>
    {
        private readonly CinemaDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public IdentitySeeder(CinemaDbContext dbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager, IValidator entityValidator, 
            ILogger<IdentitySeeder> logger) : base(entityValidator, logger)
        {
            this.dbContext = dbContext;

            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedEntityData()
        {
            await this.SeedRoles();
            await this.SeedUsers();
        }

        public UserManager<ApplicationUser> UserManager
            => this.userManager;

        public RoleManager<IdentityRole<Guid>> RoleManager
            => this.roleManager;

        private async Task SeedRoles()
        {
            string[] roles = { "Admin", "Manager", "User" };

            foreach (string role in roles)
            {
                bool roleExists = await this.RoleManager
                    .RoleExistsAsync(role);
                if (!roleExists)
                {
                    IdentityResult result = await this.RoleManager
                        .CreateAsync(new IdentityRole<Guid>(role));
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Format(FailedToCreateRole, role));
                    }
                }
            }
        }
        
        private async Task SeedUsers()
        {
            await this.SeedUser("admin@example.com", "Admin@123", "Admin");
            await this.SeedUser("appManager@example.com", "123asd", "Manager");
            await this.SeedUser("appUser@example.com", "123asd", "User");
        }

        private async Task SeedUser(string email, string password, string role)
        {
            ApplicationUser? user = await this.UserManager
                .FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email
                };

                IdentityResult createUserResult = await this.UserManager
                    .CreateAsync(user, password);
                if (!createUserResult.Succeeded)
                {
                    throw new Exception(string.Format(FailedToCreateUser, email));
                }
            }

            bool isInRole = await this.UserManager
                .IsInRoleAsync(user, role);
            if (!isInRole)
            {
                IdentityResult addRoleResult = await this.UserManager
                    .AddToRoleAsync(user, role);
                if (!addRoleResult.Succeeded)
                {
                    throw new Exception(string.Format(FailedToAssignUserToRole, role, email));
                }
            }
        }
    }
}
