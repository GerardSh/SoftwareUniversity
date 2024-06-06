namespace BorderControl
{
    public class Human : IIdentifiable
    {
        public Human(string name, int age, string iD)
        {
            Id = iD;
            Name = name;
            Age = age;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id}{Name}{Age}";
        }
    }
}
