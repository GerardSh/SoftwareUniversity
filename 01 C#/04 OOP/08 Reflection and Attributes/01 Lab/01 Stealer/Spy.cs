using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] nameOfFieldsToInvestigate)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(classToInvestigate);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Instance);

            var classInstance = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {type.FullName}");

            foreach (var field in fields.Where(x => nameOfFieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
