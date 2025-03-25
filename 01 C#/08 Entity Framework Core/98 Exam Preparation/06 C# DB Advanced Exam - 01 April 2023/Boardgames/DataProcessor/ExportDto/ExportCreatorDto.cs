using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorDto
    {
        [XmlAttribute]
        public int BoardgamesCount { get; set; }

        public string CreatorName { get; set; } = null!;

        [XmlArray("Boardgames")]
        [XmlArrayItem("Boardgame")]
        public List<ExportBoardgameDto> Boardgames { get; set; } = null!;
    }
}
