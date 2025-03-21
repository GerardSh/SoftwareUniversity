﻿namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoryDto
    {
        [XmlElement("name")]
        public string Name = null!;

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
