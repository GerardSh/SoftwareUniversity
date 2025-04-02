using Microsoft.AspNetCore.Identity;

namespace WarehouseApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Id = Guid.NewGuid();
        }

        public string FullName { get; set; }
    }
}
