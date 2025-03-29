using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var households = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != (PaymentStatus)1))
                .OrderBy(h => h.ContactPerson)
                .Select(h => new ExportHouseholdDto
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                            .Where(e => e.PaymentStatus != (PaymentStatus)1)
                            .OrderBy(e => e.DueDate)
                            .ThenBy(e => e.Amount.ToString())
                            .Select(e => new ExportExpenseDto()
                            {
                                ExpenseName = e.ExpenseName,
                                Amount = e.Amount.ToString("f2"),
                                PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                                ServiceName = e.Service.ServiceName
                            })
                            .ToList()
                })
                .ToList();

            var result = XmlHelper.Serialize(households, "Households");
            return result;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var services = context.Services
                .Select(s => new
                {
                    s.ServiceName,
                    Suppliers = s.SuppliersServices
                         .Select(ss => ss.Supplier)
                         .Select(s => new
                         {
                             s.SupplierName
                         })
                        .OrderBy(s => s.SupplierName)
                        .ToList()
                        
                })
                .OrderBy(s => s.ServiceName)
                .ToList();

            var result = JsonConvert.SerializeObject(services, Formatting.Indented);
            return result;
        }
    }
}
