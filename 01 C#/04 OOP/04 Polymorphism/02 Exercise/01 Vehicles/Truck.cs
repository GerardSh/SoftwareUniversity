namespace Vehicles
{
    public class Truck : Vehicle
    {
        double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity)
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
            FuelQuantity += fuel * 0.95;
        }
    }
}
