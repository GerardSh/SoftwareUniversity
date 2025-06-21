using Microsoft.AspNetCore.Identity;

namespace BookVerse.DataModels
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        public string PublisherId { get; set; } = null!;

        public virtual IdentityUser Publisher { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<UserBook> UsersBooks { get; set; }
            = new HashSet<UserBook>();
    }
}
