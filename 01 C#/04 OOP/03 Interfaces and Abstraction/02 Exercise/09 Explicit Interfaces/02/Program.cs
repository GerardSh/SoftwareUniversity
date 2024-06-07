using System.Text;

namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main()
        {
            string input;

            var sb = new StringBuilder();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = elements[0];
                string country = elements[1];
                int age = int.Parse(elements[2]);

                Citizen citizen = new Citizen(name, country, age);
                IResident resident = citizen;

                sb.AppendLine(citizen.GetName());
                sb.AppendLine(resident.GetName());
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}