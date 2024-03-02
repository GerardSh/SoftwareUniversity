using System.Text;

int[] keys = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string input;

while ((input = Console.ReadLine()) != "find")
{
    string treasureMap = GetTreasureText(keys, input);
    string type = GetTypeAndCordinates(treasureMap, '&', '&');
    string coordinates = GetTypeAndCordinates(treasureMap, '<', '>');

    Console.WriteLine($"Found {type} at {coordinates}");
}

static string GetTypeAndCordinates(string treasureMap, char firstSymbol, char secondSymbol)
{
    int startIndx = treasureMap.IndexOf(firstSymbol) + 1;
    int endIndx = treasureMap.LastIndexOf(secondSymbol);

    return treasureMap.Substring(startIndx, endIndx - startIndx);
}

static string GetTreasureText(int[] keys, string input)
{
    StringBuilder treasure = new StringBuilder();

    for (int i = 0; i < input.Length; i++)
    {
        treasure.Append((char)(input[i] - keys[i % keys.Length]));
    }

    return treasure.ToString();
}