List<string> items = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "Craft!")
{
    string[] commands = input
        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    string item = commands[1];

    if (command == "Collect")
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
    }
    else if (command == "Drop")
    {
        items.Remove(item);
    }
    else if (command == "Combine Items")
    {
        string[] itemsToCombine = item
            .Split(":", StringSplitOptions.RemoveEmptyEntries);

        string oldItem = itemsToCombine[0];
        string newItem = itemsToCombine[1];

        if (items.Contains(oldItem))
        {
            items.Insert(items.IndexOf(oldItem) + 1, newItem);
        }
    }
    else
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            items.Add(item);
        }
    }
}

Console.WriteLine(string.Join(", ", items));