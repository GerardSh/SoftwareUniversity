namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Text.Json.Serialization;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var output = new StringBuilder();

            var clientDtos = XmlHelper.Deserialize<ImportClientDto[]>(xmlString, "Clients");

            if (clientDtos == null || clientDtos.Count() == 0) return string.Empty;

            var clientsToBeAdded = new List<Client>();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    var isStreetNumberValid = int.TryParse(addressDto.StreetNumber, out int streetNumber);

                    if (!IsValid(addressDto) || !isStreetNumberValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var address = new Address()
                    {
                        City = addressDto.City,
                        Country = addressDto.Country,
                        PostCode = addressDto.PostCode,
                        StreetName = addressDto.StreetName,
                        StreetNumber = streetNumber,
                    };

                    client.Addresses.Add(address);
                }

                clientsToBeAdded.Add(client);
                output.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(clientsToBeAdded);
            context.SaveChanges();

            return output.ToString().Trim();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var output = new StringBuilder();

            var invDtos = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);

            if (invDtos == null || invDtos.Count() == 0) return string.Empty;

            var validInvs = new List<Invoice>();

            foreach (var invDto in invDtos)
            {
                bool isIssueDateValid = DateTime.TryParse(invDto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime issueDate);
                bool isDueDateValid = DateTime.TryParse(invDto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);
                bool isCurrencyValid = Enum.TryParse(invDto.CurrencyType, out CurrencyType curreny)
                    && Enum.IsDefined(typeof(CurrencyType), curreny);

                if (!IsValid(invDto) || !isCurrencyValid || !isIssueDateValid || !isDueDateValid || dueDate < issueDate || invDto.Amount < 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Clients.Find(invDto.ClientId) == null)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var invoice = new Invoice()
                {
                    ClientId = invDto.ClientId,
                    DueDate = dueDate,
                    IssueDate = issueDate,
                    Amount = invDto.Amount,
                    CurrencyType = curreny,
                    Number = invDto.Number,
                };

                validInvs.Add(invoice);
                output.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvs);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var output = new StringBuilder();

            var proDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            if (proDtos == null || proDtos.Count() == 0) return string.Empty;

            var validProducts = new List<Product>();

            foreach (var proDto in proDtos)
            {
                if (!IsValid(proDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product()
                {
                    Name = proDto.Name,
                    Price = proDto.Price,
                    CategoryType = (CategoryType)proDto.CategoryType
                };

                var clientIds = context.Clients
                    .Select(c => c.Id)
                    .ToHashSet();

                foreach (var clientId in proDto.Clients)
                {
                    bool existingClient = clientIds.Contains(clientId);

                    if (!existingClient)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient()
                    {
                        ClientId = clientId,
                        Product = product
                    });
                }

                validProducts.Add(product);
                output.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
