namespace CarDealer
{
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Models;
    using DTOs.Import;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            string result;
            using CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.Migrate();
            //Console.WriteLine("Database migrated successfully!");

            string jsonFile = File.ReadAllText(@"../../../Datasets/cars.json");
            result = ImportCars(dbContext, jsonFile);

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