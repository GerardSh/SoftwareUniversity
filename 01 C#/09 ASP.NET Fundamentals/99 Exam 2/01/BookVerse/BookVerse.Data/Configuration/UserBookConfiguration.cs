using BookVerse.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Data.Configuration
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> entity)
        {
            entity
                .HasKey(ub => new { ub.UserId, ub.BookId });

            entity
                .HasOne(ub => ub.User)
                .WithMany()
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ub => ub.Book)
                .WithMany(b => b.UsersBooks)
                .HasForeignKey(ub => ub.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(ub => !ub.Book.IsDeleted);
        }
    }
}
