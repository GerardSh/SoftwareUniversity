using IdentityAdvancedDemo.Data.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAdvancedDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> MakeMeAdmin()
        {
            string roleName = "Admin";
            IdentityResult? result = null;

            if (await roleManager.RoleExistsAsync(roleName) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(roleName));
            }

            if (User.IsInRole(roleName) == false && (result == null || result.Succeeded))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    var addRoleResult = await userManager.AddToRoleAsync(user, roleName);
                    if (addRoleResult.Succeeded)
                    {
                        // Refresh sign-in to update cookie with new roles/claims
                        await signInManager.RefreshSignInAsync(user);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
