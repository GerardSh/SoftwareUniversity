namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTO.ExportDTO;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Castle.Core.Resource;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();
            dbContext.Database.Migrate();
            // Console.WriteLine("Database migrated to the latest version successfully!");

            string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            string result = GetSalesWithAppliedDiscount(dbContext);

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

                    if (!dbSupplierIds.Contains(supplierId)) continue;

                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    validParts.Add(part);
                }

                context.Parts.AddRange(validParts);
                context.SaveChanges();

                result = $"Successfully imported {validParts.Count}";
            }

            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ImportCarDto[]? carDtos = XmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars")
                .Where(IsValid)
                .ToArray();

            if (carDtos! != null)
            {
                ICollection<int> dbPartIds = context.Parts
                    .Select(p => p.Id)
                    .ToArray();

                var validCars = new List<Car>();
                var validPartsCars = new List<PartCar>();

                foreach (var carDto in carDtos)
                {
                    bool isTraveledDistanceValid = long
                        .TryParse(carDto.TraveledDistance, out long traveledDistance);

                    if (!isTraveledDistanceValid) continue;

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance
                    };

                    validCars.Add(car);

                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto.Parts
                            .Where(p => IsValid(p) && int.TryParse(p.Id, out int dummy))
                            .Select(p => int.Parse(p.Id))
                            .Distinct()
                            .ToArray();

                        foreach (var part in partIds)
                        {
                            if (!dbPartIds.Contains(part)) continue;

                            var partCar = new PartCar()
                            {
                                PartId = part,
                                CarId = car.Id
                            };

                            car.PartsCars.Add(partCar);
                        }
                    }
                }

                context.Cars.AddRange(validCars);
                context.SaveChanges();

                result = $"Successfully imported {validCars.Count}";
            }

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                        : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToArray();

            var customerSalesInfo = temp
                .OrderByDescending(x =>
                    x.SalesInfo.Sum(y => y.Prices))
                .Select(a => new ExportCustomerDto()
                {
                    FullName = a.FullName,
                    CarsBought = a.BoughtCars,
                    MoneySpent = a.SalesInfo.Sum(b => (decimal)b.Prices)
                })
                .ToArray();

            var serializerXml = new XmlSerializer(typeof(ExportCustomerDto[]),
            new XmlRootAttribute("customers"));

            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            serializerXml.Serialize(xmlResult, customerSalesInfo, nameSpaces);

            return xmlResult.ToString().TrimEnd();
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