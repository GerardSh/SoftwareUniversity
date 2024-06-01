using System.Xml.Linq;

namespace Pizza
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Pizza pizza = new Pizza(Console.ReadLine().Split()[1]);
                Dough dough = Dough();
                pizza.Dough = dough;

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    Topping topping = Topping(input);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Topping Topping(string input)
        {
            string[] elements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = elements[1];
            double weight = double.Parse(elements[2]);

            return new Topping(type, weight);
        }

        public static Dough Dough()
        {
            string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = elements[1];
            string technique = elements[2];
            double weight = double.Parse(elements[3]);

            return new Dough(type, technique, weight);
        }
    }
}
