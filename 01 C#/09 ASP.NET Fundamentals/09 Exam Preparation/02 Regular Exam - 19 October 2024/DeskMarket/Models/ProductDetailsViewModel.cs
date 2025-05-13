namespace DeskMarket.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string AddedOn { get; set; } = null!;

        public string Seller { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public bool HasBought { get; set; }
    }
}
