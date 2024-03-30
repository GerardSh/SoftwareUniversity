string message = Console.ReadLine();

string input;

while ((input = Console.ReadLine()) != "Reveal")
{
    string[] commands = input
        .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "InsertSpace")
    {
        int index = int.Parse(commands[1]);

        message = message.Insert(index, " ");

        Console.WriteLine(message);
    }
    else if (command == "Reverse")
    {
        string substring = commands[1];

        if (message.Contains(substring))
        {
            message = message.Remove(message.IndexOf(substring), substring.Length);

            substring = string.Concat(substring.Reverse());

            message = message + substring;

            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("error");
        }
    }
    else if (command == "ChangeAll")
    {
        string substring = commands[1];
        string replacment = commands[2];

        while (message.Contains(substring))
        {
            message = message.Replace(substring, replacment);
        }

        Console.WriteLine(message);
    }
}

Console.WriteLine($"You have a new text message: {message}");




//2
using System.Text;

StringBuilder message = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Reveal")
{
    string[] elements = input
        .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "InsertSpace")
    {
        int index = int.Parse(elements[1]);

        message.Insert(index, " ");
    }
    else if (command == "Reverse")
    {
        string textToReverse = elements[1];

        int index = message.ToString().IndexOf(textToReverse);

        if (index != -1)
        {
            message.Remove(index, textToReverse.Length);
            message.Append(string.Concat(textToReverse.Reverse()));
        }
        else
        {
            Console.WriteLine("error");
            continue;
        }
    }
    else if (command == "ChangeAll")
    {
        string oldValue = elements[1];
        string newValue = elements[2];

        while (message.ToString().Contains(oldValue))
        {
            message.Replace(oldValue, newValue);
        }
    }

    Console.WriteLine(message);
}

Console.WriteLine($"You have a new text message: {message}");