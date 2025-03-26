using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static CinemaApp.Common.Constants.EntityConstants;
using static CinemaApp.Common.Constants.EntityConstants.Movie;

namespace CinemaApp.Data.Dtos
{
    [XmlType(nameof(Movie))]
    public class UserWatchlistMovieDto
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        [XmlAttribute(nameof(Title))]
        public string Title { get; set; } = null!;
    }
}
