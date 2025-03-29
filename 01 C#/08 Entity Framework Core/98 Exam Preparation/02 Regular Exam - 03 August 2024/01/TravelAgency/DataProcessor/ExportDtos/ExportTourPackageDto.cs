namespace TravelAgency.DataProcessor.ExportDtos
{
    public class ExportTourPackageDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
