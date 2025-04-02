using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Clients in the system")]
    public class Client
    {
        [Comment("Client identifier")]
        public Guid Id { get; set; }

        [Comment("Client's name")]
        public required string Name { get; set; }

        [Comment("Client's address")]
        public required string Address { get; set; }

        [Comment("Client's phone number")]
        public string? PhoneNumber { get; set; }

        [Comment("Client's email address")]
        public string? Email { get; set; }

        public virtual ICollection<ImportInvoice> ImportInvoices { get; set; }
            = new HashSet<ImportInvoice>();

        public virtual ICollection<ExportInvoice> ExportInvoices { get; set; }
            = new HashSet<ExportInvoice>();
    }
}
