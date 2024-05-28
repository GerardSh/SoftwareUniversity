namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelConsumption = 1.25;
            Fuel -= kilometers * fuelConsumption;
        }
    }
}
