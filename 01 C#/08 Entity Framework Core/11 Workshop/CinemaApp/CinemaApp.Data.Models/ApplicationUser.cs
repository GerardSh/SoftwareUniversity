using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Id = Guid.NewGuid();
        }

        // ICollection<T> is used as a type to benefit from higher abstraction
        // HashSet<T> is chose as implementation type, since users can add many movies to watchlist and will benefit from the look-up times
        public ICollection<ApplicationUserMovie> Watchlist { get; set; } = new HashSet<ApplicationUserMovie>();

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
