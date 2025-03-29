using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class ImportBookingDto
    {
        [Required]
        public string BookingDate { get; set; } = null!;

        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string CustomerName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string TourPackageName { get; set; } = null!;

    }
}
