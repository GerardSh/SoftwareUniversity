using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType(nameof(Country))]
    public class ImportCountryDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string CountryName { get; set; } = null!;

        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
    }
}
