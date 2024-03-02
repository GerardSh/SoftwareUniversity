int numberCommands = int.Parse(Console.ReadLine());

List<string> guests = new List<string>(numberCommands);

for (int i = 0; i < numberCommands; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = input[0];

    if (input.Length == 3)
    {
        if (guests.Contains(name))
        {
            Console.WriteLine($"{name} is already in the list!");
        }
        else
        {
            guests.Add(name);
        }
    }
    else
    {
        if (!guests.Remove(name))
        {
            Console.WriteLine($"{name} is not in the list!");
        }
    }
}

Console.WriteLine(string.Join("\n", guests));