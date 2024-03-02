Dictionary<string, int> counts = new Dictionary<string, int>();

string input;

while ((input = Console.ReadLine()) != "stop")
{
    string resource = input;
    int quantity = int.Parse(Console.ReadLine());

    if (!counts.ContainsKey(resource))
    {
        counts.Add(resource, 0);
    }

    counts[resource] += quantity;
}

foreach (var kvp in counts)
{
    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
}