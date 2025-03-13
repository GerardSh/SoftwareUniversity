namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportSupplierDto
    {
        [Required]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(IsImporter))]
        public bool IsImporter { get; set; }
    }
}