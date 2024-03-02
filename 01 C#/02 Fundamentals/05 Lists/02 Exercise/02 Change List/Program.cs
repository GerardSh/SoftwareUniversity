List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "end")
{
    string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commands[0];

    if (command == "Delete")
    {
        int element = int.Parse(commands[1]);
        list.RemoveAll(x => x == element);
    }
    else
    {
        int element = int.Parse(commands[1]);
        int position = int.Parse(commands[2]);

        list.Insert(position, element);
    }
}

Console.WriteLine(string.Join(" ", list));