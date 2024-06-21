using System.Text;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            Hired = false;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Rate { get; set; }

        public int Days { get; set; }

        public bool Hired { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.Append($"--Rate per day: {Rate} BGN");

            return sb.ToString();
        }
    }
}
