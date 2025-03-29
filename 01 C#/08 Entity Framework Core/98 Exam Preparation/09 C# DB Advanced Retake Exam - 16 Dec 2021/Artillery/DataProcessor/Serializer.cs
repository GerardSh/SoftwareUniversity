
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;
    using System.Text.Json.Nodes;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .OrderBy(s => s.ShellWeight)
                .Select(s => new
                {
                    s.ShellWeight,
                    s.Caliber,
                    Guns = s.Guns
                    .Where(g => g.GunType == (GunType)3)
                    .OrderByDescending(g => g.GunWeight)
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        g.GunWeight,
                        g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                })
                .ToList();

            var result = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    BarrelLength = g.BarrelLength.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                        .Select(cg => cg.Country)
                        .Where(c => c.ArmySize > 4500000)
                        .OrderBy(c => c.ArmySize)
                        .Select(c => new ExportCountryDto()
                        {
                            Country = c.CountryName,
                            ArmySize = c.ArmySize.ToString(),
                        })
                        .ToList()
                })
                .ToList();

            var result = XmlHelper.Serialize(guns, "Guns");
            return result;
        }
    }
}
