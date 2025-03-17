namespace CarDealer
{
    using CarDealer.Data;
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

            // string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            string result = GetLocalSuppliers(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ImportSupplierDto[]? supplierDtos = XmlHelper
                .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers")
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
            ImportPartDto[]? partDtos = XmlHelper
                .Deserialize<ImportPartDto[]>(inputXml, "Parts")
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
            ImportCarDto[]? carDtos = XmlHelper
                .Deserialize<ImportCarDto[]>(inputXml, "Cars")
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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomerDto[]? customerDtos = XmlHelper
                .Deserialize<ImportCustomerDto[]>(inputXml, "Customers")
                .Where(IsValid)
                .ToArray();

            if (customerDtos != null)
            {
                var validCustomers = new List<Customer>();

                foreach (var customerDto in customerDtos)
                {
                    bool isBirthDateValid = DateTime.TryParse(customerDto.Birthdate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);  
                    bool isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                    if (!isBirthDateValid || !isYoungDriverValid) continue;

                    var customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    validCustomers.Add(customer);
                }

                context.Customers.AddRange(validCustomers);
                context.SaveChanges();

                result = $"Successfully imported {validCustomers.Count}";
            }

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ImportSaleDto[]? saleDtos = XmlHelper
              .Deserialize<ImportSaleDto[]>(inputXml, "Sales")
              .Where(IsValid)
              .ToArray();

            if (saleDtos != null)
            {
                var dbCarIds = context.Cars
                    .Select(c => c.Id)
                    .ToArray();

                var validSales = new List<Sale>();

                foreach (var saleDto in saleDtos)
                {
                    bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int customerId);
                    bool isCarIdValid = int.TryParse(saleDto.CarId, out int carId);
                    bool isDiscountValid = decimal.TryParse(saleDto.Discount, out decimal discount);

                    if (!isCustomerIdValid || !isCarIdValid || !isDiscountValid) continue;

                    if (!dbCarIds.Contains(carId)) continue;

                    var sale = new Sale()
                    {
                        CarId = carId,
                        CustomerId = customerId,
                        Discount = discount
                    };

                    validSales.Add(sale);
                }

                context.Sales.AddRange(validSales);
                context.SaveChanges();

                result = $"Successfully imported {validSales.Count}";
            }

            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new ExportCarWithOverDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            result = XmlHelper.Serialize(cars, "cars");

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportCarBmwDto
                {
                    Id = c.Id.ToString(),
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance.ToString()
                })
                .ToList();

            result = XmlHelper.Serialize(bmwCars, "cars");

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportSupplierDto()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count().ToString()
                })
                .ToList();

            result = XmlHelper.Serialize(localSuppliers, "suppliers");

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

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleAppliedDiscountDTO[] sales = context.Sales
                .Select(s => new ExportSaleAppliedDiscountDTO()
                {
                    Car = new ExportCarWithAttrDTO()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount =
                        Math.Round((double)(s.Car.PartsCars
                            .Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            var serializerXml = new XmlSerializer(typeof(ExportSaleAppliedDiscountDTO[]),
            new XmlRootAttribute("sales"));

            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            serializerXml.Serialize(xmlResult, sales, nameSpaces);

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