namespace ConsoleApp
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public void Drive(double distanceToTravel)
        {
            double fuelNeeded = distanceToTravel * FuelConsumption;

            if (fuelNeeded > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= fuelNeeded;
                TraveledDistance += distanceToTravel;
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {

                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionOneKm = double.Parse(carData[2]);

                cars.Add(new Car()
                {
                    FuelAmount = fuelAmount,
                    FuelConsumption = fuelConsumptionOneKm,
                    Model = model
                });
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commands[1];
                double distanceToTravel = double.Parse(commands[2]);

                cars.FirstOrDefault(x => x.Model == model).Drive(distanceToTravel);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}