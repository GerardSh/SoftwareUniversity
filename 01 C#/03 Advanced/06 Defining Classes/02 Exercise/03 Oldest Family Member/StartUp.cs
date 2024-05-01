namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] memberData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = memberData[0];
                int age = int.Parse(memberData[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}