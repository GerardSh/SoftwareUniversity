using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarWithOverDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]

        public string Model { get; set; } = null!;

        [XmlElement("traveledDistance")]

        public string TraveledDistance { get; set; } = null!;
    }
}
