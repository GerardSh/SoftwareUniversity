namespace BookShop.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        = new HashSet<Book>();
    }
}