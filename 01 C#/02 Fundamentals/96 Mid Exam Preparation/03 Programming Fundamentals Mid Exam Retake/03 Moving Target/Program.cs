List<int> targets = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    int index = int.Parse(commands[1]);

    if (command == "Shoot")
    {
        int power = int.Parse(commands[2]);

        if (index < 0 || index >= targets.Count)
        {
            continue;
        }

        targets[index] -= power;

        if (targets[index] <= 0)
        {
            targets.RemoveAt(index);
        }
    }
    else if (command == "Add")
    {
        int value = int.Parse(commands[2]);

        if (index < 0 || index >= targets.Count)
        {
            Console.WriteLine("Invalid placement!");
        }
        else
        {
            targets.Insert(index, value);
        }
    }
    else
    {
        int radius = int.Parse(commands[2]);

        if (index - radius < 0 || index + radius >= targets.Count)
        {
            Console.WriteLine("Strike missed!");
            continue;
        }

        targets.RemoveRange(index - radius, radius * 2 + 1);
    }
}

Console.WriteLine(string.Join("|", targets));