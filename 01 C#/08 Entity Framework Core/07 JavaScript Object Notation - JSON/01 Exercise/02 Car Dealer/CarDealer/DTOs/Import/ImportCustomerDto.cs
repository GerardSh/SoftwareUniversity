namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCustomerDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonProperty("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}