namespace Horizons.GCommon
{
    public static class ValidationConstants
    {
        public static class Destination
        {
            public const int DestinationNameMinLength = 3;
            public const int DestinationNameMaxLength = 80;

            public const int DestinationDescriptionMinLength = 10;
            public const int DestinationDescriptionMaxLength = 250;

            public const string DestinationImageUrl = "Image URL";
            public const string DestinationPublishedOn = "Published On";

            public const string DestinationPublishedOnFormat = "dd-MM-yyyy";
        }

        public static class Terrain
        {
            public const int TerrainNameMinLength = 3;
            public const int TerrainNameMaxLength = 20;
        }
    }
}