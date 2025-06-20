using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;

        public virtual IdentityUser Seller { get; set; } = null!;

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<ProductClient> ProductsClients { get; set; } 
            = new HashSet<ProductClient>();
    }

}
