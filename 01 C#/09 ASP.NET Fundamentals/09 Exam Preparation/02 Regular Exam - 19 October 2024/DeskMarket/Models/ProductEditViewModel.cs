using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models
{
    public class ProductEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), ProductPriceMinRange, ProductPriceMaxRange, ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = $"Date must be in {ProductDateTimeFormat}.")]
        public string AddedOn { get; set; } = null!;

        [Required]
        public string SellerId { get; set; } = null!;

        [Range(CategoryIdMinValue, CategoryIdMaxValue)]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
            = new HashSet<CategoryViewModel>();
    }
}
