using NetPay.Data;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Data.Models.Enums;
using NetPay.Utilities;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            ExportHouseholdExpensesDto[] households = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .OrderBy(h => h.ContactPerson)
                .Select(h => new ExportHouseholdExpensesDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                    .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                    .OrderBy(e => e.DueDate.ToString())
                    .ThenBy(e => e.Amount.ToString()).ToArray()
                    .Select(e => new ExportExpenseDto
                    {
                        ExpenseName = e.ExpenseName,
                        Amount = e.Amount.ToString("f2"),
                        PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                        ServiceName = e.Service.ServiceName
                    })
                    .ToArray()
                })
                .ToArray();

            string result = XmlHelper.Serialize(households, "Households");

            return result;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var services = context.Services
                 .Select(s => new
                 {
                     ServiceName = s.ServiceName,
                     Suppliers = s.SuppliersServices
                         .Select(ss => ss.Supplier)
                         .Select(s => new
                         {
                             s.SupplierName,
                         })
                         .OrderBy(s => s.SupplierName)
                         .ToArray()
                 })
                 .OrderBy(s => s.ServiceName)
                 .ToArray();

            string result = JsonConvert.SerializeObject(services, Formatting.Indented);

            return result;
        }
    }
}
