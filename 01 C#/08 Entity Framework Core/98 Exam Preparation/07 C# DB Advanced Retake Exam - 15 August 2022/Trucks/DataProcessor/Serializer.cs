namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Reflection.Metadata;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ExportDespatcherDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToList()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToList();

            var result = XmlHelper.Serialize(despatchers, "Despatchers");
            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                        .Select(ct => ct.Truck)
                        .Where(t => t.TankCapacity >= capacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.RegistrationNumber,
                            t.VinNumber,
                            t.TankCapacity,
                            t.CargoCapacity,
                            CategoryType = t.CategoryType.ToString(),
                            MakeType = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToList()
                })
                .OrderByDescending(c => c.Trucks.Count)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(clients, Formatting.Indented);
            return result;
        }
    }
}
