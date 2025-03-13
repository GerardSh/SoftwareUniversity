namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportSaleDto
    {
        [Required]
        [JsonProperty("carId")]
        public int CarId { get; set; }

        [Required]
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [Required]
        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}