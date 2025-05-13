using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        [Required]
        public string ClientId { get; set; } = null!;

        public virtual IdentityUser Client { get; set; } = null!;
    }
}