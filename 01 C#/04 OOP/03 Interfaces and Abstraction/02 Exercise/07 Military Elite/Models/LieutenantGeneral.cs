using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILietenantGeneral, ISoldier, IPrivate
    {
        List<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<Private>();
        }

        public IReadOnlyCollection<Private> Privates => privates;

        public void AddPrivate(Private @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Privates:");

            foreach (var item in privates)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

