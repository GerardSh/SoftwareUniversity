namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCategoryDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}
