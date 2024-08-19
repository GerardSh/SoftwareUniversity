namespace Prototype
{
    public class Program
    {
        public static void Main()
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Chicken", "Fetta", "Lettuce");
            sandwichMenu["BicMac"] = new Sandwich("Wheat", "Pork", "", "Lettuce, Tomato, Cucumber");

            Sandwich sandwich = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["BLT"].DeepCopy() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["BicMac"].Clone() as Sandwich;
            Sandwich sandwich4 = sandwichMenu["BicMac"].DeepCopy() as Sandwich;
        }
    }
}