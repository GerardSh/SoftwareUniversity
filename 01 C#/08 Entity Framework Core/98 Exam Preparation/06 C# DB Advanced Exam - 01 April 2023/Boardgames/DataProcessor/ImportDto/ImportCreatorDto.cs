using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        [XmlArrayItem("Boardgame")]
        public List<ImportBoardgameDto> Boardgames { get; set; } = null!;
    }
}
