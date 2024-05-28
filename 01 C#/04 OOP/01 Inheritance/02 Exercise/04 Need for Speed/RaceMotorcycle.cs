namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
    : base(horsePower, fuel)
        {

        }
        public override void Drive(double kilometers)
        {
            double fuelConsumption = 8;
            Fuel -= kilometers * fuelConsumption;
        }
    }
}
