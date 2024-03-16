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