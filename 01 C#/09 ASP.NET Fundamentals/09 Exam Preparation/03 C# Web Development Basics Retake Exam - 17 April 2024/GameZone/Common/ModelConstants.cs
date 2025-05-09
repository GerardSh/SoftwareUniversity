namespace GameZone.Common
{
    public static class ModelConstants
    {
        public static class Game
        {
            public const int GameMinTitleLength = 2;
            public const int GameMaxTitleLength = 50;
            public const int GameMinDescriptionLength = 10;
            public const int GameMaxDescriptionLength = 500;
            public const string GameReleasedOnDateFormat = " yyyy-MM-dd";
        }

        public static class Genre
        {
            public const int GenreMinNameLength = 3;
            public const int GenreMaxNameLength = 25;
        }
    }
}
