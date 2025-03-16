namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();
            dbContext.Database.Migrate();
            Console.WriteLine("Database migrated to the latest version successfully!");

            string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string result = ImportSuppliers(dbContext, inputXml);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ImportSupplierDto[]? supplierDtos = XmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers")
                .Where(IsValid)
                .ToArray();

            if (supplierDtos != null)
            {
                var validSuppliers = new List<Supplier>();

                foreach (var supplierDto in supplierDtos)
                {
                    bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);

                    if (!isImporterValid) continue;

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter
                    };

                    validSuppliers.Add(supplier);
                }

                context.Suppliers.AddRange(validSuppliers);
                context.SaveChanges();

                result = $"Successfully imported {validSuppliers.Count}";
            }

            return result;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ImportPartDto[]? partDtos = XmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts")
                .Where(IsValid)
                .ToArray();

            if (partDtos != null)
            {
                var dbSupplierIds = context.Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                var validParts = new List<Part>();

                foreach (var partDto in partDtos)
                {
                    bool isPriceValid = decimal
                        .TryParse(partDto.Price, out decimal price);
                    bool isQuantityValid = int
                        .TryParse(partDto.Quantity, out int quantity);
                    bool isSupplierValid = int
                        .TryParse(partDto.SupplierId, out int supplierId);

                    if (!isPriceValid || !isQuantityValid || !isSupplierValid) continue;
                }
            }

        }

        //Helper method
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults);

            return isValid;
        }
    }
}