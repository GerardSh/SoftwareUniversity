using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [Required]
        [MinLength(9)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), "5", "1000")]
        public decimal Price { get; set; }

        [Range(0,4)]
        public int CategoryType { get; set; }

        public HashSet<int> Clients { get; set; } = null!;
    }
}
