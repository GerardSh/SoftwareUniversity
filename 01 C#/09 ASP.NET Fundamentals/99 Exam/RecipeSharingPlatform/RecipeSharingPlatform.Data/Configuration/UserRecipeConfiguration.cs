using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Data.Configuration
{
    public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> entity)
        {
            entity
                .HasKey(ur => new { ur.UserId, ur.RecipeId });

            entity
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ur => ur.Recipe)
                .WithMany(r => r.UsersRecipes)
                .HasForeignKey(ur => ur.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(ur => !ur.Recipe.IsDeleted);
        }
    }
}
