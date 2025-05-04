using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetIdentity.Data.Models
{
    [Comment("An order placed by a user.")]
    public class Order
    {
        [Key]
        [Comment("The unique identifier for the order.")]
        public int Id { get; set; }

        [Required]
        [Comment("The date and time the order was placed.")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("The price of the order.")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(450)]
        [ForeignKey(nameof(User))]
        [Comment("The user who placed the order.")]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
