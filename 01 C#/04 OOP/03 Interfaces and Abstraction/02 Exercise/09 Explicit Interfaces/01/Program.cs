namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main()
        {
            List<IResident> residents = new List<IResident>();
            List<IPerson> persons = new List<IPerson>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = elements[0];
                string country = elements[1];
                int age = int.Parse(elements[2]);

                var citizen = new Citizen(name, country, age);

                residents.Add(citizen);
                persons.Add(citizen);
            }

            for (int i = 0; i < residents.Count; i++)
            {
                Console.WriteLine(persons[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}