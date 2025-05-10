using Microsoft.AspNetCore.Identity;
namespace Horizons.Data.Models
{
    public class UserDestination
    {
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; } = null!;
    }
}
