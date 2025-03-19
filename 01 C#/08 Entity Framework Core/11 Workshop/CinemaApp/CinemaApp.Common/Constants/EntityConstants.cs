namespace CinemaApp.Common.Constants
{
    public static class EntityConstants
    {
        // Decimal(18,2) is suitable SQL Server Type for money
        public const string MoneyType = "decimal(18,2)";

        public static class Cinema
        {
            // It's good to omit having magic strings and numbers in the code
            // You can also cite the SWS based on which you decided to take this value
            // Example:
            /// <summary>
            /// SWS_Cinema_EntityValidation_700152878: Cinema name should be able to store text with length up to 256
            /// </summary>
            public const int NameMaxLength = 256;

            /// <summary>
            /// SWS_Cinema_EntityValidation_700152879: Cinema location should be able to store text with length up to 256
            /// </summary>
            public const int LocationMaxLength = 256;
        }

        public static class CinemaMovie
        {
            /// <summary>
            /// CinemaMovie Showtimes should be string with length = 5
            /// </summary>
            public const int ShowtimesMaxLength = 5;

            /// <summary>
            /// CinemaMovie Showtimes should have default format {00000}
            /// </summary>
            public const string ShowtimesDefaultFormat = "00000";
        }

        public static class Movie
        {
            /// <summary>
            /// Movie Title should be able to store text with length up to 150
            /// </summary>
            public const int TitleMaxLength = 150;

            /// <summary>
            /// Movie Genre should be able to store text with length up to 30
            /// </summary>
            public const int GenreMaxLength = 30;

            /// <summary>
            /// Movie Director should be able to store text with length up to 150
            /// </summary>
            public const int DirectorMaxLength = 150;

            /// <summary>
            /// Movie Description should be able to store text with length up to 1024
            /// </summary>
            public const int DescriptionMaxLength = 1024;

            /// <summary>
            /// Movie ImageUrl should be able to store text with length up to 2048 (refer URI RFC)
            /// </summary>
            public const int ImageUrlMaxLength = 2048;
        }
    }
}
