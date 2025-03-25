namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var output = new StringBuilder();
            var disDtos = XmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            if (disDtos != null && disDtos.Length > 0)
            {
                var districtsInDb = dbContext.Districts;
                var districtsToBeAdded = new List<District>();

                foreach (var disDto in disDtos)
                {
                    bool isRegionValid = Enum.TryParse(disDto.Region, out Region region);

                    if (!IsValid(disDto) || !isRegionValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (districtsInDb.Any(d => d.Name == disDto.Name)
                        || districtsToBeAdded.Any(d => d.Name == disDto.Name))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validProperties = new List<Property>();

                    foreach (var dtoProperty in disDto.Properties)
                    {
                        bool isDateValid = DateTime.TryParseExact(dtoProperty.DateOfAcquisition,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                        if (!IsValid(dtoProperty) || !isDateValid)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dbContext.Properties.Any(p=> p.PropertyIdentifier == dtoProperty.PropertyIdentifier || p.Address == dtoProperty.Address) ||
                                 validProperties.Any(p => p.PropertyIdentifier == dtoProperty.PropertyIdentifier || p.Address == dtoProperty.Address))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        var property = new Property()
                        {
                            Address = dtoProperty.Address,
                            DateOfAcquisition = date,
                            Area = dtoProperty.Area,
                            Details = dtoProperty.Details,
                            PropertyIdentifier = dtoProperty.PropertyIdentifier,
                        };

                        validProperties.Add(property);
                    }

                    var district = new District()
                    {
                        Name = disDto.Name,
                        PostalCode = disDto.PostalCode,
                        Region = region,
                        Properties = validProperties
                    };

                    districtsToBeAdded.Add(district);
                    output.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
                }

                dbContext.AddRange(districtsToBeAdded);
                dbContext.SaveChanges();
            }

            return output.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var output = new StringBuilder();
            var citizenDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            if (citizenDtos != null && citizenDtos.Length > 0)
            {
                var citizensToBeAdded = new List<Citizen>();

                foreach (var citizenDto in citizenDtos)
                {
                    bool isMaritalStatus = Enum.TryParse(citizenDto.MaritalStatus, out MaritalStatus status);
                    bool isDateValid = DateTime.TryParseExact(citizenDto.BirthDate,
                         "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                    if (!IsValid(citizenDto) || !isMaritalStatus || !isDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var citizen = new Citizen()
                    {
                        FirstName = citizenDto.FirstName,
                        LastName = citizenDto.LastName,
                        BirthDate = date,
                        MaritalStatus = status,
                    };

                    foreach (var propertyId in citizenDto.Properties)
                    {
                        bool isPropertyExisting = dbContext.Properties.Find(propertyId) != null;

                        if (!isPropertyExisting)
                        {
                            continue;
                        }

                        citizen.PropertiesCitizens.Add(new PropertyCitizen()
                        {
                            CitizenId = citizen.Id,
                            PropertyId = propertyId
                        });
                    }

                    citizensToBeAdded.Add(citizen);
                    output.AppendLine(String.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
                }

                dbContext.Citizens.AddRange(citizensToBeAdded);
                dbContext.SaveChanges();
            }

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
