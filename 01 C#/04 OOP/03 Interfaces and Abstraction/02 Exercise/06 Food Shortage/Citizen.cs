namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string iD, string birthdate)
        {
            Id = iD;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
