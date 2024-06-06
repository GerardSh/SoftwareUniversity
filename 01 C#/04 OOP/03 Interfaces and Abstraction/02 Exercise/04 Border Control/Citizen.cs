namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string iD)
        {
            Id = iD;
            Name = name;
            Age = age;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
