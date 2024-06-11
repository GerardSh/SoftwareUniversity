namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {

            Vehicle car = GetVehicle();
            Vehicle truck = GetVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];
                string vehicle = elements[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(elements[2]);

                    if (vehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else
                    {
                        truck.Drive(distance);
                    }
                }
                else
                {
                    double liters = double.Parse(elements[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        private static Vehicle GetVehicle()
        {
            string[] vehicleData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleData[0];
            double fuelQuantity = double.Parse(vehicleData[1]);
            double fuelConsumption = double.Parse(vehicleData[2]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }
        }
    }
}
