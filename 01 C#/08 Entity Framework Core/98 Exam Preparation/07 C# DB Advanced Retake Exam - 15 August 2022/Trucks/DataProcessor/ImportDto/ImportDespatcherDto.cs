using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public string Position { get; set; } = null!;

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public List<ImportTruckDto> Trucks { get; set; } = null!;
    }
}
