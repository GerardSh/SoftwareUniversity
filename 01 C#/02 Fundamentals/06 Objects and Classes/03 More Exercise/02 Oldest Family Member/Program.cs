namespace ConsoleApp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(x => x.Age).First();
        }
    }

    class Program
    {
        public static void Main()
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                family.AddMember(new Person() { Age = age, Name = name });
            }

            Person oldestFamilyMember = family.GetOldestMember();

            Console.WriteLine(oldestFamilyMember.Name + " " + oldestFamilyMember.Age);
        }
    }
}