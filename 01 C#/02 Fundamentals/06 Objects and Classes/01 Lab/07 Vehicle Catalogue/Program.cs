using System.Text;

namespace ConsoleApp
{
    class BrandModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    class Truck
    {
        public int Weight { get; set; }
        public BrandModel BrandModel { get; set; }
    }

    class Car
    {
        public int HorsePower { get; set; }
        public BrandModel BrandModel { get; set; }
    }

    class Catalog
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder result = new StringBuilder();

        //    if (Cars.Count > 0)
        //    {
        //        result.AppendLine("Cars:");

        //        foreach (var car in Cars)
        //        {
        //            result.AppendLine($"{car.BrandModel.Brand}: {car.BrandModel.Model} - {car.HorsePower}hp");
        //        }
        //    }

        //    if (Trucks.Count > 0)
        //    {
        //        result.AppendLine("Trucks:");

        //        foreach (var truck in Trucks)
        //        {
        //            result.AppendLine($"{truck.BrandModel.Brand}: {truck.BrandModel.Model} - {truck.Weight}kg");
        //        }
        //    }

        //    return result.ToString();
        //}
    }

    class Program
    {
        static void Main()
        {

            string input;

            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] autoDetails = input
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string carType = autoDetails[0];
                string brand = autoDetails[1];
                string model = autoDetails[2];

                if (carType == "Car")
                {
                    int horsePower = int.Parse(autoDetails[3]);

                    cars.Add(new Car()
                    {
                        BrandModel = new BrandModel()
                        {
                            Brand = brand,
                            Model = model,
                        },
                        HorsePower = horsePower
                    });
                }
                else if (carType == "Truck")
                {
                    int weightKg = int.Parse(autoDetails[3]);

                    trucks.Add(new Truck()
                    {
                        BrandModel = new BrandModel()
                        {
                            Brand = brand,
                            Model = model,
                        },
                        Weight = weightKg
                    });
                }
            }

            Catalog catalog = new Catalog()
            {
                Cars = cars,
                Trucks = trucks
            };

            catalog.Cars = catalog.Cars.OrderBy(b => b.BrandModel.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(b => b.BrandModel.Brand).ToList();

            //Console.WriteLine(catalog); // Will invoke the overridden ToString method

            if (catalog.Cars.Count > 0)
            {

                Console.WriteLine("Cars:");

                foreach (var car in catalog.Cars)
                {
                    Console.WriteLine($"{car.BrandModel.Brand}: {car.BrandModel.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in catalog.Trucks)
                {
                    Console.WriteLine($"{truck.BrandModel.Brand}: {truck.BrandModel.Model} - {truck.Weight}kg");
                }
            }

        }
    }
}