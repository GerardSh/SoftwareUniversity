using System.ComponentModel.DataAnnotations;

using CinemaApp.Common.Constants;

namespace CinemaApp.Data.Dtos
{
    public class CinemaMovieDto
    {
        [Required]
        [MinLength(EntityConstants.Movie.TitleMinLength)]
        [MaxLength(EntityConstants.Movie.TitleMaxLength)]
        public string Movie { get; set; } = null!;

        [Required]
        [MinLength(EntityConstants.Cinema.NameMinLength)]
        [MaxLength(EntityConstants.Cinema.NameMaxLength)]
        public string Cinema { get; set; } = null!;

        [Required]
        [Range(EntityConstants.CinemaMovie.AvailableTicketsMinValue, 
            EntityConstants.CinemaMovie.AvailableTicketsMaxValue)]
        public int AvailableTickets { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
        
        public string? Showtimes { get; set; }
    }
}
