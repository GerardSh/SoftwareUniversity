namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity)
        {
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity { get; protected set; }

        protected abstract double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
