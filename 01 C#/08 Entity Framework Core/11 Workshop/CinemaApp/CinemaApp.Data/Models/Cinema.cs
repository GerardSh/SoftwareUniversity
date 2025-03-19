using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models
{
    [Comment("Cinemas in the system")]
    public class Cinema
    {
        [Comment("Cinema identifier")]
        public Guid Id { get; set; }
        
        [Comment("Cinema name")]
        public string Name { get; set; } = null!;
        
        [Comment("Cinema location")]
        public string Location { get; set; } = null!;

        [Comment("Shows if cinema is deleted")]
        public bool IsDeleted { get; set; }

        // Navigation collection is not virtual, because we are not expected to use LazyLoading
        // ICollection<T> is used as a type to benefit from higher abstraction
        // List<T> is chose as implementation type, since we do not expect to have many movies in the cinema at the same time
        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}
