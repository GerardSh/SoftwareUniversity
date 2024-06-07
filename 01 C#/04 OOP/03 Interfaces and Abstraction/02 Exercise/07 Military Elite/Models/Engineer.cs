using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer, IPrivate, ISpecialisedSoldier
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
               : base(id, firstName, lastName, corps, salary)
        {
            Repairs = new List<Repair>();
        }

        public decimal Salary { get; set; }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
