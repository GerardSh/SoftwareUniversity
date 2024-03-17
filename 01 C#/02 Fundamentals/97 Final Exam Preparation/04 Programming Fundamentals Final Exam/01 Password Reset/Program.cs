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