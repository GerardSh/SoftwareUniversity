namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCarDto
    {
        [Required]
        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [Required]
        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [Required]
        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }

        [Required]
        [JsonProperty("partsId")]
        public int[] PartIds { get; set; } = null!;
    }
}