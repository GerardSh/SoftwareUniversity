namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var countryDtos = XmlHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            if (countryDtos == null || countryDtos.Count() == 0) return string.Empty;

            var validCountires = new List<Country>();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };

                validCountires.Add(country);
                output.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountires);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var manfDtos = XmlHelper.Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");

            if (manfDtos == null || manfDtos.Count() == 0) return string.Empty;

            var validManufacturers = new List<Manufacturer>();

            var manufacturerNamesInDb = context.Manufacturers
                .Select(m => m.ManufacturerName)
                .ToList();

            foreach (var manfDto in manfDtos)
            {
                if (!IsValid(manfDto)
                    || manufacturerNamesInDb.Contains(manfDto.ManufacturerName)
                    || validManufacturers.Any(m => m.ManufacturerName == manfDto.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = manfDto.ManufacturerName,
                    Founded = manfDto.Founded,
                };

                string[] foundedInfo = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string neededInfo = $"{foundedInfo[foundedInfo.Length - 2]}, {foundedInfo[foundedInfo.Length - 1]}";
                validManufacturers.Add(manufacturer);
                output.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, neededInfo));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            var shellDtos = XmlHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            if (shellDtos == null || shellDtos.Count() == 0) return string.Empty;

            var validShells = new List<Shell>();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                };

                validShells.Add(shell);
                output.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var output = new StringBuilder();

            var gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            if (gunDtos == null || gunDtos.Count() == 0) return string.Empty;

            var validGuns = new List<Gun>();

            foreach (var gunDto in gunDtos)
            {
                bool isGunValid = Enum.TryParse(gunDto.GunType, out GunType gunType)
                    && Enum.IsDefined(typeof(GunType), gunType);

                if (!IsValid(gunDto) || !isGunValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId,
                };

                foreach (var countryId in gunDto.Countries)
                {
                    var countryGun = new CountryGun()
                    {
                        CountryId = countryId.Id,
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                validGuns.Add(gun);
                output.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}