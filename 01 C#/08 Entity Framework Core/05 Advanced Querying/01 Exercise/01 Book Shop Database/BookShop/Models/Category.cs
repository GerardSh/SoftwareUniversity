namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public virtual ICollection<BookCategory> CategoryBooks { get; set; }
         = new HashSet<BookCategory>();
    }
}