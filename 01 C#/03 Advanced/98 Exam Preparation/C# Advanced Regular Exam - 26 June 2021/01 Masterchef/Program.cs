
namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var freshnessLevel = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var createdProducts = new SortedDictionary<string, int>();

            while (ingredients.Any() && freshnessLevel.Any())
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFrenshnessLevel = freshnessLevel.Pop();

                int sum = currentIngredient * currentFrenshnessLevel;

                string createdProduct = CreateProduct(sum);

                if (createdProduct != null)
                {
                    if (!createdProducts.ContainsKey(createdProduct))
                    {
                        createdProducts[createdProduct] = 0;
                    }

                    createdProducts[createdProduct]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngredient + 5);
                }
            }

            if (createdProducts.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
            Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var kvp in createdProducts)
            {
                Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
            }
        }

        private static string CreateProduct(int sum)
        {
            if (sum == 150)
            {
                return "Dipping sauce";
            }
            else if (sum == 250)
            {
                return "Green salad";
            }
            else if (sum == 300)
            {
                return "Chocolate cake";
            }
            else if (sum == 400)
            {
                return "Lobster";
            }
            else
            {
                return null;
            }
        }
    }
}