using System.ComponentModel.DataAnnotations;

namespace Horizons.Web.ViewModels.Destination
{
    public class DestinationDeleteInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        [Required]
        public string PublisherId { get; set; } = null!;
    }
}
