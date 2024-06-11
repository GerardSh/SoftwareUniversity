namespace Vehicles
{
    public class Bus : Vehicle
    {
        double fuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, tankCapacity)
        {
            FuelConsumption = fuelConsumption;
        }

        protected override double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public override void Drive(double distance, string capacity)
        {
            if (capacity != "DriveEmpty")
            {
                FuelConsumption += 1.4;
                base.Drive(distance, "");
                FuelConsumption -= 1.4;
            }
            else
            {
                base.Drive(distance, "");
            }
        }
    }
}
