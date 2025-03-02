using BookShop.Models.Enums;

namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;

        public virtual ICollection<BookCategory> BookCategories { get; set; }
         = new HashSet<BookCategory>();
    }
}
