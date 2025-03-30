using SocialNetwork.Data.Models;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType(nameof(Post))]
    public class ExportPostDto
    {
        public string Content { get; set; } = null!;

        public string CreatedAt { get; set; } = null!;
    }
}
