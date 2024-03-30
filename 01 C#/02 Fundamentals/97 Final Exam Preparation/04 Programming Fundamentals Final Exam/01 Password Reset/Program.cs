using System.Text;

string password = Console.ReadLine();

string input;

while ((input = Console.ReadLine()) != "Done")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "TakeOdd")
    {
        StringBuilder newPassword = new StringBuilder();

        for (int i = 0; i < password.Length; i++)
        {
            if (i % 2 == 1)
            {
                newPassword.Append(password[i]);
            }
        }

        password = newPassword.ToString();

        Console.WriteLine(password);
    }
    else if (command == "Cut")
    {
        int index = int.Parse(commands[1]);
        int length = int.Parse(commands[2]);

        string substring = password.Substring(index, length);

        int firstOccurrenceIndex = password.IndexOf(substring);

        password = password.Remove(firstOccurrenceIndex, substring.Length);

        Console.WriteLine(password);
    }
    else if (command == "Substitute")
    {
        string substring = commands[1];
        string substitute = commands[2];

        if (!password.Contains(substring))
        {
            Console.WriteLine("Nothing to replace!");
            continue;
        }

        while (password.Contains(substring))
        {
            password = password.Replace(substring, substitute);
        }

        Console.WriteLine(password);
    }
}

Console.WriteLine($"Your password is: {password}");




//2
string password = Console.ReadLine();

string input;

while ((input = Console.ReadLine()) != "Done")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "TakeOdd")
    {
        string editedPassword = "";

        for (int i = 0; i < password.Length; i++)
        {
            if (i % 2 == 1)
            {
                editedPassword += password[i];
            }
        }

        password = editedPassword;
    }
    else if (command == "Cut")
    {
        int index = int.Parse(elements[1]);
        int length = int.Parse(elements[2]);

        string substring = password.Substring(index, length);
        password = password.Remove(password.IndexOf(substring), length);
    }
    else
    {
        string substring = elements[1];
        string substitute = elements[2];

        if (password.Contains(substring))
        {
            while (password.Contains(substring))
            {
                password = password.Replace(substring, substitute);
            }
        }
        else
        {
            Console.WriteLine($"Nothing to replace!");
            continue;
        }
    }

    Console.WriteLine(password);
}

Console.WriteLine($"Your password is: {password}");