namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> set = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();

                Person person = new Person(personData[0], int.Parse(personData[1]));

                sortedSet.Add(person);
                set.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(set.Count);
        }
    }
}