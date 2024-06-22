namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var materrialsByValues = new Dictionary<int, string>()
            {
                {40, "Datura Bombs"},
                {60, "Cherry Bombs"},
                {120,"Smoke Decoy Bombs"}
            };

            var countByBombs = new SortedDictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            var pouchCreated = false;

            while (effects.Any() && casings.Any())
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Pop();

                int sum = currentEffect + currentCasing;

                if (materrialsByValues.ContainsKey(sum))
                {
                    string bombType = materrialsByValues[sum];

                    countByBombs[bombType]++;

                    effects.Dequeue();
                }
                else
                {
                    casings.Push(currentCasing - 5);
                }

                if (countByBombs.Count == 3)
                {
                    bool allBombsCreated = true;

                    foreach (var item in countByBombs)
                    {
                        if (item.Value < 3)
                        {
                            allBombsCreated = false;
                            break;
                        }
                    }

                    if (allBombsCreated)
                    {
                        pouchCreated = true;
                        break;
                    }
                }
            }

            if (pouchCreated)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            foreach (var kvp in countByBombs)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}