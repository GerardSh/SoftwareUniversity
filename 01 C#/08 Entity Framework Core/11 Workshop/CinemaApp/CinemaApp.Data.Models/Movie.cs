using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models
{
    [Comment("Movie in the system")]
    public class Movie
    {
        [Comment("Movie identifier")]
        public Guid Id { get; set; }
        
        [Comment("Movie title")]
        public string Title { get; set; } = null!;
        
        [Comment("Movie genre")]
        public string Genre { get; set; } = null!;
        
        [Comment("Movie release date")]
        public DateTime ReleaseDate { get; set; }
        
        [Comment("Movie director")]
        public string Director { get; set; } = null!;
        
        [Comment("Movie duration")]
        public int Duration { get; set; }
        
        [Comment("Movie description")]
        public string Description { get; set; } = null!;
        
        [Comment("Movie image url from the image store")]
        public string? ImageUrl { get; set; }

        [Comment("Shows if movie is deleted")]
        public bool IsDeleted { get; set; }

        // Navigation collections are not virtual, because we are not expected to use LazyLoading
        // ICollection<T> is used as a type to benefit from higher abstraction
        // Both List<T> and HashSet<T> may be suitable as implementation type. Choose based on the scale of the application.
        public ICollection<CinemaMovie> MovieCinemas { get; set; } = new HashSet<CinemaMovie>();

        // ICollection<T> is used as a type to benefit from higher abstraction
        // HashSet<T> is chose as implementation type, since many users can add the movie to watchlist and will benefit from the look-up times
        public ICollection<ApplicationUserMovie> MovieApplicationUsers { get; set; } = new HashSet<ApplicationUserMovie>();
    }
}
