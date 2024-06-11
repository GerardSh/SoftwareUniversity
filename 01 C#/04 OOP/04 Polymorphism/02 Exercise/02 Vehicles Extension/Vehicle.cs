namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double TankCapacity { get; }

        protected Vehicle(double fuelQuantity, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            TankCapacity = tankCapacity;
        }

        

        public double FuelQuantity { get; protected set; }

        protected abstract double FuelConsumption { get; set; }

        public virtual void Drive(double distance, string capacity)
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
            if (fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            else if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{FuelQuantity:f2}";
        }
    }
}
