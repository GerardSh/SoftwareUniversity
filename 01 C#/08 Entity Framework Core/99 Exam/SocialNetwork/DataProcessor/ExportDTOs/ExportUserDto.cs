using SocialNetwork.Data.Models;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType(nameof(User))]
    public class ExportUserDto
    {
        [XmlAttribute("Friendships")]
        public int Friendships { get; set; }

        public string Username { get; set; } = null!;

        [XmlArray("Posts")]
        [XmlArrayItem("Post")]
        public List<ExportPostDto> Posts { get; set; } = null!;
    }
}
