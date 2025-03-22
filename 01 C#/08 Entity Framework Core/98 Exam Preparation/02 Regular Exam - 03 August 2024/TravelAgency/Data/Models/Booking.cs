using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(TourPackage))]
        public int TourPackageId { get; set; }

        public virtual TourPackage TourPackage { get; set; } = null!;
    }
}