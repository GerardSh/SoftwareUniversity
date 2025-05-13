namespace DeskMarket.Common
{
    public static class ValidationConstants
    {
        // Product
        public const int ProductNameMinLength = 2;
        public const int ProductNameMaxLength = 60;
        public const int ProductDescriptionMinLength = 10;
        public const int ProductDescriptionMaxLength = 250;
        public const string ProductPriceMinRange = "1";
        public const string ProductPriceMaxRange = "3000";
        public const string ProductDateTimeFormat = "dd-MM-yyyy";

        // Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;
        public const int CategoryIdMinValue = 1;
        public const int CategoryIdMaxValue = 5;
    }
}
