using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [ForeignKey(nameof(TourPackage))]
        public int TourPackageId { get; set; }

        public TourPackage TourPackage { get; set; } = null!;

        [ForeignKey(nameof(Guide))]
        public int GuideId { get; set; }

        public Guide Guide { get; set; } = null!;
    }
}
