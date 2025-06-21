using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookVerse.DataModels;

using static BookVerse.GCommon.ValidationConstants.Genre;

namespace BookVerse.Data.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity
                .HasKey(g => g.Id);

            entity
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(GenreNameMaxLength);

            entity
                .HasData(GenerateSeedGenres());
        }

        private List<Genre> GenerateSeedGenres()
        {
            return new List<Genre>
            {
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Thriller" },
                new Genre { Id = 3, Name = "Romance" },
                new Genre { Id = 4, Name = "Sci-Fi" },
                new Genre { Id = 5, Name = "History" },
                new Genre { Id = 6, Name = "Non-Fiction" }
            };
        }
    }
}
