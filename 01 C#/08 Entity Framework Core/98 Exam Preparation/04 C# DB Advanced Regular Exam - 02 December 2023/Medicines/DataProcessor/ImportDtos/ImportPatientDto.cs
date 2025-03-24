using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public List<int> Medicines { get; set; }
            = new List<int>();
    }
}
