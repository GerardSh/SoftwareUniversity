namespace BirthdayCelebrations
{
    class Program
    {
        public static void Main()
        {
            List<IBirthdateable> petsAndCitizens = new List<IBirthdateable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = elements[0];

                string name = elements[1];

                if (type == "Citizen")
                {
                    petsAndCitizens.Add(new Citizen(name, int.Parse(elements[2]), elements[3], elements[4]));
                }
                else if (type == "Pet")
                {
                    petsAndCitizens.Add(new Pet(name, elements[2]));
                }
            }

            string yearToPrint = Console.ReadLine();

            foreach (var entity in petsAndCitizens)
            {
                if (entity.Birthdate.EndsWith(yearToPrint))
                {
                    Console.WriteLine(entity.Birthdate);
                }
            }
        }
    }
}