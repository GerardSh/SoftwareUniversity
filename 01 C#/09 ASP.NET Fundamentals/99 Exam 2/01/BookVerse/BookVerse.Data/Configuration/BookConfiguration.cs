using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookVerse.DataModels;

using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        private readonly string defaultUserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd";

        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity
                .HasKey(b => b.Id);

            entity
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(BookTitleMaxLength);

            entity
                .Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(BookDescriptionMaxLength);

            entity
                .Property(b => b.CoverImageUrl)
                .IsRequired(false);

            entity
                .Property(b => b.PublisherId)
                .IsRequired();

            entity
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(b => b.PublishedOn)
                .IsRequired();

            entity
                .Property(b => b.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(b => b.IsDeleted == false);

            entity
                .HasData(GenerateSeedBooks());
        }

        private List<Book> GenerateSeedBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Whispers of the Mountain",
                    Description = "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUserId,
                    PublishedOn = DateTime.Now,
                    GenreId = 1,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 2,
                    Title = "Shadows in the Fog",
                    Description = "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUserId,
                    PublishedOn = DateTime.Now,
                    GenreId = 2,
                    IsDeleted = false
                },
                new Book
                {
                    Id = 3,
                    Title = "Letters from the Heart",
                    Description = "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.",
                    CoverImageUrl = "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg",
                    PublisherId = defaultUserId,
                    PublishedOn = DateTime.Now,
                    GenreId = 3,
                    IsDeleted = false
                }
            };
        }
    }
}
