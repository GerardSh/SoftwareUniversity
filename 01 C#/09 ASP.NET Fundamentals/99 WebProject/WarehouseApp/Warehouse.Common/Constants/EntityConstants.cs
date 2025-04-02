namespace WarehouseApp.Common.Constants
{
    public static class EntityConstants
    {
        public const string MoneyType = "decimal(18,2)";

        public static class ImportInvoice
        {
            public const int InvoiceNumberMinLength = 3;

            public const int InvoiceNumberMaxLength = 15;
        }

        public static class ExportInvoice
        {
            public const int InvoiceNumberMinLength = 3;

            public const int InvoiceNumberMaxLength = 15;
        }

        public static class Client
        {
            public const int NameMinLength = 3;

            public const int NameMaxLength = 50;

            public const int AddressMinLength = 5;

            public const int AddressMaxLength = 80;

            public const int PhoneNumberMinLength = 10;

            public const int PhoneNumberMaxLength = 20;

            public const int EmailMinLength = 5;

            public const int EmailMaxLength = 40;
        }

        public static class Warehouse
        {
            public const int AddressMinLength = 5;

            public const int AddressMaxLength = 50;
        }

        public static class Product
        {
            public const int ProductNameMinLength = 3;

            public const int ProductNameMaxLength = 100;

            public const int DescriptionMinLength = 5;

            public const int DescriptionMaxLength = 50;
        }
    }
}
