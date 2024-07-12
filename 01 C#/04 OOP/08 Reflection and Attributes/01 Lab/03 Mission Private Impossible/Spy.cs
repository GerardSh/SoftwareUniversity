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
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            var classInstance = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {type.FullName}");

            foreach (var field in fields.Where(x => nameOfFieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(className);

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            var nonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in nonPublicMethods)
            {
                if (method.Name.Contains("get_"))
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
            }

            var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in publicMethods)
            {
                if (method.Name.Contains("set_"))
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
