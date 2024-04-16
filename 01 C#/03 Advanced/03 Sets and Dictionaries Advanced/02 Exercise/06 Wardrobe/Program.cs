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

foreach (var color in wardrobe)
{
    Console.WriteLine($"{color.Key} clothes:");

    foreach (var dress in color.Value)
    {
        Console.Write($"* {dress.Key} - {dress.Value}");

        if (searchedItem[0] == color.Key && searchedItem[1] == dress.Key)
        {
            Console.Write(" (found!)");
        }

        Console.WriteLine();
    }
}