using System.Text;

namespace Cars
{
    internal class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {     
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get ; set ; }

        public string Model { get ; set ; }

        public string Color { get ; set ; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().Trim();
        }
    }
}
