namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var coffeDrinksByQuantities = new Dictionary<int, string>()

            {
                {50, "Cortado" },
                {75, "Espresso" },
                {100, "Capuccino" },
                {150, "Americano" },
                {200, "Latte" },
            };

            var coffeeQuantities = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var milkQuantities = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var countByCoffeeDrinks = new Dictionary<string, int>();

            while (coffeeQuantities.Any() && milkQuantities.Any())
            {
                int coffeeQuantity = coffeeQuantities.Dequeue();
                int milkQuantity = milkQuantities.Pop();

                int sum = coffeeQuantity + milkQuantity;

                if (coffeDrinksByQuantities.ContainsKey(sum))
                {
                    string item = coffeDrinksByQuantities[sum];

                    if (!countByCoffeeDrinks.ContainsKey(item))
                    {
                        countByCoffeeDrinks[item] = 0;
                    }

                    countByCoffeeDrinks[item]++;

                    continue;
                }

                milkQuantities.Push(milkQuantity - 5);
            }

            if (!coffeeQuantities.Any() && !milkQuantities.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!coffeeQuantities.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantities)}");
            }

            if (!milkQuantities.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
            }

            foreach (var kvp in countByCoffeeDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}