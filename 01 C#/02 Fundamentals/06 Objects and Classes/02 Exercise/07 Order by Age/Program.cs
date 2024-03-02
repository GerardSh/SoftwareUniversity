namespace ConsoleApp
{
    class People
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main()
        {
            string input;

            List<People> people = new List<People>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInformation = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInformation[0];
                string iD = personInformation[1];
                int age = int.Parse(personInformation[2]);

                People person = new People()
                {
                    Name = name,
                    ID = iD,
                    Age = age
                };

                people.Add(person);
            }

            people = people.OrderBy(p => p.Age).ToList();

            foreach (People person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}