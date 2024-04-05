using System.Text;

StringBuilder username = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Registration")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Letters")
    {
        string casing = elements[1];

        username = new StringBuilder(username.ToString().ToUpper());

        if (casing == "Lower")
        {
            username = new StringBuilder(username.ToString().ToLower());
        }

        Console.WriteLine(username);
    }
    else if (command == "Reverse")
    {
        int startIndex = int.Parse(elements[1]);
        int endIndex = int.Parse(elements[2]);
        int count = endIndex - startIndex + 1;

        if (startIndex >= 0 && endIndex >= startIndex && endIndex < username.Length)
        {
            string substring = username.ToString().Substring(startIndex, count);

            Console.WriteLine(string.Concat(substring.Reverse()));
        }
    }
    else if (command == "Substring")
    {
        string substring = elements[1];

        if (username.ToString().Contains(substring))
        {
            username.Replace(substring, string.Empty);

            Console.WriteLine(username);
        }
        else
        {
            Console.WriteLine($"The username {username} doesn't contain {substring}.");
        }
    }
    else if (command == "Replace")
    {
        char symbol = char.Parse(elements[1]);

        if (username.ToString().Contains(symbol))
        {
            username.Replace(symbol, '-');
        }

        Console.WriteLine(username);
    }
    else if (command == "IsValid")
    {
        char symbol = char.Parse(elements[1]);

        if (username.ToString().Contains(symbol))
        {
            Console.WriteLine("Valid username.");
        }
        else
        {
            Console.WriteLine($"{symbol} must be contained in your username.");
        }
    }
}