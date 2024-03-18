List<string> items = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "Yohoho!")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "Loot")
    {
        for (int i = 1; i < commands.Length; i++)
        {
            if (!items.Contains(commands[i]))
            {
                items.Insert(0, commands[i]);
            }
        }
    }
    else if (command == "Drop")
    {
        int index = int.Parse(commands[1]);

        if (index >= 0 && index < items.Count)
        {
            string temp = items[index];

            items.RemoveAt(index);
            items.Add(temp);
        }
    }
    else
    {
        int count = int.Parse(commands[1]);
        List<string> stolenItems = new List<string>();

        if (items.Count < count)
        {
            count = items.Count;
        }

        stolenItems = items.TakeLast(count).ToList();
        items.RemoveRange(items.Count - count, count);

        Console.WriteLine(string.Join(", ", stolenItems));
    }
}

if (items.Count == 0)
{
    Console.WriteLine("Failed treasure hunt.");
}
else
{
    double averageGain = 1.0 * items.Sum(x => x.Length) / items.Count;
    Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
}