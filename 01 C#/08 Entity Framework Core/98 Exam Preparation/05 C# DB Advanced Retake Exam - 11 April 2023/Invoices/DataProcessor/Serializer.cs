namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .ToArray()
                .Select(c => new ExportClientDto
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = i.Amount,
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            Currency = i.CurrencyType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToList();

            var result = XmlHelper.Serialize(clients, "Clients");
            return result;
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .ToArray()
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Select(pc => pc.Client)
                        .Where(c => c.Name.Length >= nameLength)
                        .OrderBy(c => c.Name)
                        .Select(c => new
                        {
                            c.Name,
                            c.NumberVat
                        })
                        .ToList()
                })
                .OrderByDescending(p => p.Clients.Count())
                .ThenBy(p => p.Name)
                .Take(5)
                .ToList();

            string result =JsonConvert.SerializeObject(products, Formatting.Indented);
            return result;
        }
    }
}