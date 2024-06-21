namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            var flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            var productByWater = new Dictionary<double, string>()
            {
                {50, "Croissant"},
                {40, "Muffin"},
                {30, "Baguette"},
                {20, "Bagel"}
            };

            var countByProducts = new SortedDictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();

                double sum = currentWater + currentFlour;

                double percentage = currentWater / sum * 100;

                if (productByWater.ContainsKey(percentage))
                {
                    string product = productByWater[percentage];

                    if (!countByProducts.ContainsKey(product))
                    {
                        countByProducts[product] = 0;
                    }

                    countByProducts[product]++;

                    continue;
                }

                if (!countByProducts.ContainsKey("Croissant"))
                {
                    countByProducts["Croissant"] = 0;
                }

                countByProducts["Croissant"]++;

                flour.Push(currentFlour - currentWater);
            }

            foreach (var kvp in countByProducts.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (!water.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (!flour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}