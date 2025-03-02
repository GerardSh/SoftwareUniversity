using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class BookCategory
    {
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
