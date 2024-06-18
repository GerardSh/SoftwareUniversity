public class Program
{
    static void Main()
    {
        var textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        var medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        var countByHealingItems = new SortedDictionary<string, int>();

        var healingItemsMap = new Dictionary<int, string>()
        {
            {30, "Patch"},
            {40, "Bandage"},
            {100, "MedKit"}
        };

        while (textiles.Any() && medicaments.Any())
        {
            int textile = textiles.Dequeue();
            int medicament = medicaments.Pop();

            int sum = textile + medicament;

            if (healingItemsMap.ContainsKey(sum))
            {
                string item = healingItemsMap[sum];

                if (!countByHealingItems.ContainsKey(item))
                {
                    countByHealingItems[item] = 0;
                }

                countByHealingItems[item]++;

                continue;
            }

            if (sum > 100)
            {
                if (!countByHealingItems.ContainsKey("MedKit"))
                {
                    countByHealingItems["MedKit"] = 0;
                }

                countByHealingItems["MedKit"]++;

                int remainingSum = sum - 100;

                if (medicaments.Count > 0)
                {
                    medicaments.Push(medicaments.Pop() + remainingSum);
                }
                else
                {
                    medicaments.Push(remainingSum);
                }

                continue;
            }

            medicaments.Push(medicament + 10);
        }

        if (!textiles.Any() && !medicaments.Any())
        {
            Console.WriteLine("Textiles and medicaments are both empty.");
        }
        else if (!textiles.Any())
        {
            Console.WriteLine("Textiles are empty.");
        }
        else
        {
            Console.WriteLine("Medicaments are empty.");
        }

        foreach (var kvp in countByHealingItems.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }

        if (medicaments.Any())
        {
            Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
        }

        if (textiles.Any())
        {
            Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
        }
    }
}