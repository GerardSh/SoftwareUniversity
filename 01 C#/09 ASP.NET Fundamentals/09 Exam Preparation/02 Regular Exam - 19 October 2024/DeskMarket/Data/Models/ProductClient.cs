using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        public string ClientId { get; set; } = null!;

        public IdentityUser Client { get; set; } = null!;
    }
}