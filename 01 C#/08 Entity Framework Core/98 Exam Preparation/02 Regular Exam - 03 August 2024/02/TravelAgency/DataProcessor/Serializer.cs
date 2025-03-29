using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                 .Where(g => g.Language == (Language)3)
                 .Select(g => new ExportGuideDto()
                 {
                     FullName = g.FullName,
                     TourPackages = g.TourPackagesGuides
                                    .Select(tg => tg.TourPackage)
                                    .OrderByDescending(t => t.Price)
                                    .ThenBy(t => t.PackageName)
                                    .Select(t => new ExportTourPackageDto()
                                    {
                                        Name = t.PackageName,
                                        Description = t.Description,
                                        Price = t.Price.ToString()
                                    })
                                    .ToList()
                 })
                 .OrderByDescending(g => g.TourPackages.Count)
                 .ThenBy(g => g.FullName)
                 .ToList();

            var result = XmlHelper.Serialize(guides, "Guides");
            return result;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                               .OrderBy(b => b.BookingDate)
                               .Where(b=> b.TourPackage.PackageName == "Horse Riding Tour")
                               .Select(b => new
                               {
                                   TourPackageName = b.TourPackage.PackageName,
                                   Date = b.BookingDate.ToString("yyyy-MM-dd")
                               })
                               .ToList()
                })
                .OrderByDescending(c => c.Bookings.Count)
                .ThenBy(c => c.FullName)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }
    }
}
