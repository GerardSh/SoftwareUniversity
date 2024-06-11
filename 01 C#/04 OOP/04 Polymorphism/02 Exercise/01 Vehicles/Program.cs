namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantityCar = double.Parse(carData[1]);
            double fuelConsumptionCar = double.Parse(carData[2]);
            Vehicle car = new Car(fuelQuantityCar, fuelConsumptionCar);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantityTruck = double.Parse(truckData[1]);
            double fuelConsumptionTruck = double.Parse(truckData[2]);
            Vehicle truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck);

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
    }
}