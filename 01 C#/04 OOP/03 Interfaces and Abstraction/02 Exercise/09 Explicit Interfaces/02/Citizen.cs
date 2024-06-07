namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }

        public string Country { get; }

        public int Age { get; }

        public string GetName() => Name;

        string IResident.GetName() => $"Mr/Ms/Mrs {Name}";
    }
}
