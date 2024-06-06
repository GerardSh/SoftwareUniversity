using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando, IPrivate, ISpecialisedSoldier
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, corps)
        { 
            Salary = salary;
            Missions = new List<Mission>();
        }

        public decimal Salary { get; set; }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
