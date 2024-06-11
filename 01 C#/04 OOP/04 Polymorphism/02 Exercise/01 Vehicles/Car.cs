namespace Vehicles
{
    public class Car : Vehicle
    {
        private double fuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity)
        {
            FuelConsumption = fuelConsumption;
        }

        protected override double FuelConsumption
        {
            get => fuelConsumption;

            set
            {
                fuelConsumption += value + 0.9;
            }
        }
    }
}
