string[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

var keyValuePair = new Dictionary<char, int>();

foreach (string line in array)
{
    foreach (char c in line)
    {
        if (!keyValuePair.ContainsKey(c))
        {
            keyValuePair.Add(c, 0);
        }

        keyValuePair[c]++;
    }
}

foreach (var kvp in keyValuePair)
{
    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
}