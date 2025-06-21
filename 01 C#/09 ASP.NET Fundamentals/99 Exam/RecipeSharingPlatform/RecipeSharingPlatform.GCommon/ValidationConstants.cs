namespace RecipeSharingPlatform.GCommon
{
    public static class ValidationConstants
    {
        public static class Recipe
        {
            public const int RecipeTitleMinLength = 3;
            public const int RecipeTitleMaxLength = 80;

            public const int RecipeInstructionsMinLength = 10;
            public const int RecipeInstructionsMaxLength = 250;

            public const string RecipeCreatedOnFormat = "yyyy-MM-dd";
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;

            public const int CategoryRangeMin = 1;
            public const int CategoryRangeMax = 6;
        }
    }
}
