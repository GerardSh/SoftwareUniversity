string[] array = Console.ReadLine().ToLower()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> elements = new Dictionary<string, int>();

foreach (string item in array)
{
    if (!elements.ContainsKey(item))
    {
        elements.Add(item, 0);
    }

    elements[item]++;
}

foreach (var item in elements)
{
    if (item.Value % 2 == 1)
    {
        Console.Write(item.Key + " ");
    }
}