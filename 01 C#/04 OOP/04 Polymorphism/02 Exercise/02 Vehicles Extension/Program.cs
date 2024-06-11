namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {

            Vehicle car = GetVehicle();
            Vehicle truck = GetVehicle();
            Vehicle bus = GetVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];
                string vehicle = elements[1];
                double parameter = double.Parse(elements[2]);

                if (vehicle == "Car")
                {
                    ExecuteCommand(command, car, parameter);
                }
                else if (vehicle == "Truck")
                {
                    ExecuteCommand(command, truck, parameter);
                }
                else
                {
                    ExecuteCommand(command, bus, parameter);
                }
            }

            Console.WriteLine($"Car: {car}");
            Console.WriteLine($"Truck: {truck}");
            Console.WriteLine($"Bus: {bus}");
        }

        private static void ExecuteCommand(string command, Vehicle vehicle, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter, "");
            }
            else if (command == "DriveEmpty" && vehicle.GetType().Name == "Bus")
            {
                vehicle.Drive(parameter, command);
            }
            else
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle GetVehicle()
        {
            string[] vehicleData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleData[0];
            double fuelQuantity = double.Parse(vehicleData[1]);
            double fuelConsumption = double.Parse(vehicleData[2]);
            double tankCapacity = double.Parse(vehicleData[3]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
        }
    }
}