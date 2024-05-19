namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = elements[0];
                int age = int.Parse(elements[1]);
                string town = elements[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            int equalPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[n - 1].CompareTo(people[i]) == 0) 
                {
                equalPeople++;
                }
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }
        }
    }
}