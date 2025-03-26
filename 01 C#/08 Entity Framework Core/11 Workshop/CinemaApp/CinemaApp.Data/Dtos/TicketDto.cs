using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Dtos
{
    [XmlType(nameof(Ticket))]
    public class TicketDto
    {
        [Required]
        [XmlElement(nameof(Price))]
        public string Price { get; set; } = null!;

        [Required]
        [XmlElement(nameof(CinemaId))]
        public string CinemaId { get; set; } = null!;

        [Required]
        [XmlElement(nameof(MovieId))]
        public string MovieId { get; set; } = null!;

        [Required]
        [XmlElement(nameof(UserId))]
        public string UserId { get; set; } = null!;
    }
}
