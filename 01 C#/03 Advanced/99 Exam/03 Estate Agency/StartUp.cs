namespace EstateAgency
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository (EstateAgency)
            EstateAgency estateAgency = new EstateAgency(5);

            // Initialize entities (RealEstate)
            RealEstate home = new RealEstate("123 Main St", "12345", 250000.0m, 120.0);
            RealEstate office = new RealEstate("456 Business Rd", "67890", 500000.0m, 300.0);
            RealEstate warehouse = new RealEstate("789 Industrial Ave", "10111", 750000.0m, 500.0);
            RealEstate store = new RealEstate("321 Market St", "12131", 200000.0m, 80.0);
            RealEstate apartment = new RealEstate("654 Elm St", "12131", 180000.0m, 70.0);

            // Get Count
            Console.WriteLine(estateAgency.Count); // 0

            // Add RealEstates
            estateAgency.AddRealEstate(home);
            estateAgency.AddRealEstate(office);
            estateAgency.AddRealEstate(warehouse);
            estateAgency.AddRealEstate(store);
            estateAgency.AddRealEstate(apartment);

            // Try to add real estate when the capacity is full
            RealEstate villa = new RealEstate("987 Luxury Ln", "16171", 1000000.0m, 600.0);
            estateAgency.AddRealEstate(villa); // Should not add as capacity is full

            // Get Count
            Console.WriteLine(estateAgency.Count); // 5

            // Remove RealEstate
            Console.WriteLine(estateAgency.RemoveRealEstate("987 Luxury Ln")); // False
            Console.WriteLine(estateAgency.RemoveRealEstate("123 Main St")); // True

            // GetRealEstate
            Console.WriteLine(string.Join(Environment.NewLine, estateAgency.GetRealEstates("12131")));
            // Address: 321 Market St, PostalCode: 12131, Price: $200000.0, Size: 80 sq.m.
            // Address: 654 Elm St, PostalCode: 12131, Price: $180000.0, Size: 70 sq.m.

            // Get Cheapest RealEstate
            Console.WriteLine(estateAgency.GetCheapest());
            // Address: 654 Elm St, PostalCode: 14151, Price: $180000.0, Size: 70 sq.m.

            // Get Largest RealEstate
            Console.WriteLine(estateAgency.GetLargest());
            // 500

            // Real Estates Report
            Console.WriteLine(estateAgency.EstateReport());
            // Real estates available:
            // Address: 456 Business Rd, PostalCode: 67890, Price: $500000.0, Size: 300 sq.m.
            // Address: 789 Industrial Ave, PostalCode: 10111, Price: $750000.0, Size: 500 sq.m.
            // Address: 321 Market St, PostalCode: 12131, Price: $200000.0, Size: 80 sq.m.
            // Address: 654 Elm St, PostalCode: 14151, Price: $180000.0, Size: 70 sq.m.  
        }
    }
}
