namespace ConsoleApp
{
    class Vehicle
    {

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }


        //public override string ToString()
        //{
        //    return $"{FirstName} {LastName}: {Grade:f2}";
        //}
    }

    class Program
    {
        static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type;

                if (vehicleData[0] == "car")
                {
                    type = "Car";
                }
                else
                {
                    type = "Truck";
                }
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsePower = int.Parse(vehicleData[3]);

                Vehicle vehicle = new Vehicle()
                {
                    Color = color,
                    HorsePower = horsePower,
                    Model = model,
                    Type = type
                };

                vehicles.Add(vehicle);
            }

            string modelInput;

            while ((modelInput = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle currentVehicle = vehicles.FirstOrDefault(v => v.Model == modelInput);


                Console.WriteLine($"Type: {currentVehicle.Type}");
                Console.WriteLine($"Model: {currentVehicle.Model}");
                Console.WriteLine($"Color: {currentVehicle.Color}");
                Console.WriteLine($"Horsepower: {currentVehicle.HorsePower}");
            }

            double carsAvrgHorsePower = CalculateAvrHorsePower(vehicles, "Car");
            double trucksAvrgHorsePower = CalculateAvrHorsePower(vehicles, "Truck");


            Console.WriteLine($"Cars have average horsepower of: {carsAvrgHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvrgHorsePower:f2}.");
        }

        private static double CalculateAvrHorsePower(List<Vehicle> vehicles, string type)
        {
            double horsePowerSum = 0;
            int vehicleCount = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Type == type)
                {
                    horsePowerSum += vehicle.HorsePower;
                    vehicleCount++;
                }
            }

            if (vehicleCount == 0)
            {
                return 0;
            }
            else
            {
                return horsePowerSum / vehicleCount;
            }
        }
    }
}