using Microsoft.AspNetCore.Identity;

namespace IdentityAdvancedDemo.Data.IdentityModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
            :base()
        {
        }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
    }
}
