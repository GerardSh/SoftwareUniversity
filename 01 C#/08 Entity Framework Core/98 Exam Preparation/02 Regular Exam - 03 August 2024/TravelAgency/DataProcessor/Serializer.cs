using NetPay.Utilities;
using Newtonsoft.Json;
using System.Linq;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                 .Where(g => g.Language == Language.Spanish)
                 .Select(g => new ExportGuideDto()
                 {
                     FullName = g.FullName,
                     TourPackages = g.TourPackagesGuides
                         .Select(tp => tp.TourPackage)
                         .Select(p => new ExportTourPackageDto()
                         {
                             Name = p.PackageName,
                             Description = p.Description,
                             Price = p.Price,
                         })
                         .OrderByDescending(p => p.Price)
                         .ToList()
                 })
                 .OrderByDescending(g => g.TourPackages.Count)
                 .ThenBy(g => g.FullName)
                 .ToArray();

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
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
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


            string result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }
    }
}
