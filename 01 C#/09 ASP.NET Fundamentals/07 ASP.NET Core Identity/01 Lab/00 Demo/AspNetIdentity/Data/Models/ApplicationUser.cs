using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(255)]
        [Comment("The first name of the user.")]
        public string? FirstName { get; set; }

        [PersonalData]
        [MaxLength(255)]
        [Comment("The last name of the user.")]
        public string? LastName { get; set; }
    }
}
