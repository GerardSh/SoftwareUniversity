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




//2
using System.Text;

StringBuilder destinations = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Travel")
{
    string[] elements = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Add Stop")
    {
        int index = int.Parse(elements[1]);
        string newStop = elements[2];

        if (index >= 0 && index < destinations.Length)
        {
            destinations.Insert(index, newStop);
        }

        Console.WriteLine(destinations);
    }
    else if (command == "Remove Stop")
    {
        int startIndex = int.Parse(elements[1]);
        int endIndex = int.Parse(elements[2]);

        if (startIndex <= endIndex && startIndex >= 0 && endIndex < destinations.Length)
        {
            destinations.Remove(startIndex, endIndex - startIndex + 1);
        }

        Console.WriteLine(destinations);
    }
    else if (command == "Switch")
    {
        string oldValue = elements[1];
        string newValue = elements[2];

        destinations.Replace(oldValue, newValue);

        Console.WriteLine(destinations);
    }
}

Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");