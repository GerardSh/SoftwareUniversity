using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

var wardrobe = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] currentItems = Regex.Split(Console.ReadLine(), @" -> |,");

    string color = currentItems[0];

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe[color] = new Dictionary<string, int>();
    }

    for (int j = 1; j < currentItems.Length; j++)
    {
        if (!wardrobe[color].ContainsKey(currentItems[j]))
        {
            wardrobe[color][currentItems[j]] = 0;
        }

        wardrobe[color][currentItems[j]]++;
    }
}

string[] searchedItem = Console.ReadLine().Split();

foreach (var colors in wardrobe)
{
    Console.WriteLine($"{colors.Key} clothes:");

    foreach (var dresses in colors.Value)
    {
        Console.Write($"* {dresses.Key} - {dresses.Value}");

        if (searchedItem[0] == colors.Key && searchedItem[1] == dresses.Key)
        {
            Console.Write(" (found!)");
        }

        Console.WriteLine();
    }
}