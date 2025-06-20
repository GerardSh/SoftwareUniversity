namespace Horizons.Common
{
    public static class ValidationConstants
    {
        // Destination
        public const int DestinationNameMinLength = 3;
        public const int DestinationNameMaxLength = 80;
        public const int DestinationDescriptionMinLength = 10;
        public const int DestinationDescriptionMaxLength = 250;
        public const string DestinationDateTimeFormat = "dd-MM-yyyy";

        // Terrain
        public const int TerrainNameMinLength = 3;
        public const int TerrainNameMaxLength = 20;
        public const int TerrainIdMinValue = 1;
        public const int TerrainIdMaxValue = 8;
    }
}
