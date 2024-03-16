string text = Console.ReadLine();

string input;

while ((input = Console.ReadLine()) != "Travel")
{
    string[] commands = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "Add Stop")
    {
        int index = int.Parse(commands[1]);
        string textToInsert = commands[2];

        if (index >= 0 && index < text.Length)
        {
            text = text.Insert(index, textToInsert);
        }

        Console.WriteLine(text);
    }
    else if (command == "Remove Stop")
    {
        int startIndex = int.Parse(commands[1]);
        int endIndex = int.Parse(commands[2]);
        int count = (endIndex - startIndex) + 1;

        if (count < 0)
        {
            Console.WriteLine(text);
            continue;
        }

        if (startIndex >= 0 && startIndex < text.Length && endIndex < text.Length)
        {
            text = text.Remove(startIndex, count);
        }

        Console.WriteLine(text);
    }
    else if (command == "Switch")
    {
        string oldString = commands[1];
        string newString = commands[2];

        text = text.Replace(oldString, newString);

        Console.WriteLine(text);
    }
}

Console.WriteLine($"Ready for world tour! Planned stops: {text}");