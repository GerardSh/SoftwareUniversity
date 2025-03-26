using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static CinemaApp.Common.Constants.EntityConstants.ApplicationUser;

namespace CinemaApp.Data.Dtos
{
    [XmlType("User")]
    public class UserWatchlistDto
    {
        [Required]
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        [XmlAttribute(nameof(Username))]
        public string Username { get; set; } = null!;

        [Required]
        [XmlArray(nameof(Movies))]
        public UserWatchlistMovieDto[] Movies { get; set; } = null!;
    }
}
