namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var output = new StringBuilder();

            var despDtos = XmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            if (despDtos == null || despDtos.Count() == 0) return string.Empty;

            var validDespatchers = new List<Despatcher>();

            foreach (var despDto in despDtos)
            {
                if (!IsValid(despDto))
                {
                    output.AppendLine(ErrorMessage); continue;
                }

                var despatcher = new Despatcher()
                {
                    Name = despDto.Name,
                    Position = despDto.Position,
                };

                foreach (var truckDto in despDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        output.AppendLine(ErrorMessage); continue;
                    }

                    var truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);
                output.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return output.ToString().Trim();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var output = new StringBuilder();

            var clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            if (clientDtos == null || clientDtos.Count() == 0) return string.Empty;

            var validClients = new List<Client>();

            var truckIds = context.Trucks
                .Select(t => t.Id)
                .ToHashSet();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (var truckId in clientDto.Trucks)
                {
                    if (!truckIds.Contains(truckId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                validClients.Add(client);
                output.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}