using System.Text;

StringBuilder message = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Finish")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Replace")
    {
        string currentChar = elements[1];
        string newChar = elements[2];

        message.Replace(currentChar, newChar);

        Console.WriteLine(message);
    }
    else if (command == "Cut")
    {
        int startIndex = int.Parse(elements[1]);
        int endIndex = int.Parse(elements[2]);
        int count = endIndex - startIndex + 1;

        if (startIndex < 0 || endIndex < startIndex || endIndex >= message.Length)
        {
            Console.WriteLine("Invalid indices!");
            continue;
        }

        message.Remove(startIndex, count);

        Console.WriteLine(message);
    }
    else if (command == "Make")
    {
        string casing = elements[1];

        string temp = message.ToString().ToUpper();


        if (casing == "Lower")
        {
            temp = temp.ToLower();
        }

        message.Clear();
        message.Append(temp);

        Console.WriteLine(message);
    }
    else if (command == "Check")
    {
        string text = elements[1];

        if (message.ToString().Contains(text))
        {
            Console.WriteLine($"Message contains {text}");
        }
        else
        {
            Console.WriteLine($"Message doesn't contain {text}");
        }
    }
    else if (command == "Sum")
    {
        int startIndex = int.Parse(elements[1]);
        int endIndex = int.Parse(elements[2]);
        int count = endIndex - startIndex + 1;

        if (startIndex < 0 || endIndex < startIndex || endIndex >= message.Length)
        {
            Console.WriteLine("Invalid indices!");
            continue;
        }

        string subString = message.ToString().Substring(startIndex, count);

        int sum = subString.Sum(x => x);

        Console.WriteLine(sum);
    }
}
//09:20:07 31.03.2024