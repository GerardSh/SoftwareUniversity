﻿namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarPartDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public string TraveledDistance { get; set; } = null!;

        [XmlArray("parts")]
        public ExportPartDto[] Parts { get; set; } = null!;
    }
}
