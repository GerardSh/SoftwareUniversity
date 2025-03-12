namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCategoryProductDto
    {
        [Required]
        [JsonProperty(nameof(CategoryId))]
        public string CategoryId { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(ProductId))]
        public string ProductId { get; set; } = null!;
    }
}
