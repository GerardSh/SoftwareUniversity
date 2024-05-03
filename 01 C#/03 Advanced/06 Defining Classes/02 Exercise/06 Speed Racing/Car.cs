namespace DefiningClasses
{
    public class Car
    {
        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumtionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumtionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public static void Drive(Car car, double distance)
        {
            double remainingFuel = car.FuelAmount - car.FuelConsumtionPerKilometer * distance;

            if (remainingFuel >= 0)
            {
                car.FuelAmount = remainingFuel;
                car.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}