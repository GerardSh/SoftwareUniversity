namespace CarDealer
{
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Models;
    using DTOs.Import;
    using System.Globalization;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            string result;
            using CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.Migrate();
            //Console.WriteLine("Database migrated successfully!");

            // string jsonFile = File.ReadAllText(@"../../../Datasets/sales.json");
            result = GetCarsWithTheirListOfParts(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[]? supplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            if (supplierDtos != null)
            {
                ICollection<Supplier> suppliers = new List<Supplier>();
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter
                    };

                    suppliers.Add(supplier);
                }

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                result = $"Successfully imported {suppliers.Count}.";
            }

            return result;
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers.Select(s => s.Id).ToList();

            ImportPartDto[]? partsDto = JsonConvert
               .DeserializeObject<ImportPartDto[]>(inputJson);

            if (partsDto != null)
            {
                ICollection<Part> validParts = new List<Part>();

                foreach (var partDto in partsDto)
                {
                    if (!IsValid(partDto)) continue;

                    if (!suppliers.Contains(partDto.SupplierId)) continue;

                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };

                    validParts.Add(part);
                }

                context.Parts.AddRange(validParts);
                context.SaveChanges();

                result = $"Successfully imported {validParts.Count}.";
            }

            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCarDto[]? carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> cars = new List<Car>();
            ICollection<int> existingPartIds = context.Parts
                    .Select(p => p.Id)
                    .ToArray();

            if (carDtos != null)
            {
                foreach (var carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TravelledDistance
                    };

                    cars.Add(car);

                    foreach (var partId in carDto.PartIds.Distinct())
                    {
                        if (!existingPartIds.Contains(partId))
                        {
                            continue;
                        }

                        PartCar partCar = new PartCar()
                        {
                            CarId = car.Id,
                            PartId = partId
                        };

                        car.PartsCars.Add(partCar);
                    }
                }

                context.Cars.AddRange(cars);
                context.SaveChanges();

                result = $"Successfully imported {cars.Count}.";
            }

            return result;
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCustomerDto[]? customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> customers = new List<Customer>();

            if (customerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = customerDto.BirthDate,
                        IsYoungDriver = customerDto.IsYoungDriver
                    };

                    customers.Add(customer);
                }

                context.Customers.AddRange(customers);
                context.SaveChanges();

                result = $"Successfully imported {customers.Count}.";
            }

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportSaleDto[]? saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> sales = new List<Sale>();

            if (saleDtos != null)
            {
                foreach (ImportSaleDto saleDto in saleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    Sale sale = new Sale
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    sales.Add(sale);
                }

                context.Sales.AddRange(sales);
                context.SaveChanges();

                result = $"Successfully imported {sales.Count}.";
            }

            return result;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            string customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            string carsJson = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return carsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                           p.Part.Name,
                           Price = p.Part.Price.ToString("F2")
                        })
                        .ToList()
                })
                .ToArray();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}