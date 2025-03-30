using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        public string Content { get; set; } = null!;

        public string CreatedAt { get; set; } = null!;

        public int CreatorId { get; set; }
    }
}
