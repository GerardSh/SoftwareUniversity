using System.ComponentModel.DataAnnotations;

namespace Horizons.Web.ViewModels.Destination
{
    public class DestinationDeleteInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Publisher { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;
    }
}
