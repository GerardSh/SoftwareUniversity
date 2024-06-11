namespace Vehicles
{
    public class Truck : Vehicle
    {
        double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, tankCapacity)
        {
            FuelConsumption = fuelConsumption;
        }

        protected override double FuelConsumption
        {
            get => fuelConsumption;

            set
            {
                fuelConsumption = value + 1.6;
            }
        }

        public override void Refuel(double fuel)
        {
            if (fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }

            base.Refuel(fuel * 0.95);
        }
    }
}
