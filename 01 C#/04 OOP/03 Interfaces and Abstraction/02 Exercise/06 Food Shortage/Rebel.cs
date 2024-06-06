namespace FoodShortage
{
    public class Rebel :IBuyer
    {
        public Rebel(string name, int age, string groupName)
        {
            Name = name;
            Age = age;
            GroupName = groupName;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string GroupName { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
