string rawActivationKey = Console.ReadLine();

string input;

while ((input = Console.ReadLine()) != "Generate")
{
    string[] commands = input
        .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

    string command = commands[0];

    if (command == "Contains")
    {
        string substring = commands[1];

        if (rawActivationKey.Contains(substring))
        {
            Console.WriteLine($"{rawActivationKey} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }
    else if (command == "Flip")
    {
        string lowerUpper = commands[1];
        int startIndx = int.Parse(commands[2]);
        int endIndx = int.Parse(commands[3]);
        int count = endIndx - startIndx;

        if (lowerUpper == "Lower")
        {
            string temp = rawActivationKey.Substring(0, startIndx);
            temp += rawActivationKey.Substring(startIndx, count).ToLower();
            temp += rawActivationKey.Substring(endIndx);
            rawActivationKey = temp;
        }
        else
        {
            string temp = rawActivationKey.Substring(0, startIndx);
            temp += rawActivationKey.Substring(startIndx, count).ToUpper();
            temp += rawActivationKey.Substring(endIndx);
            rawActivationKey = temp;
        }

        Console.WriteLine(rawActivationKey);
    }
    else if (command == "Slice")
    {
        int startIndx = int.Parse(commands[1]);
        int endIndx = int.Parse(commands[2]);
        int count = endIndx - startIndx;

        rawActivationKey = rawActivationKey.Remove(startIndx, count);

        Console.WriteLine(rawActivationKey);
    }
}

Console.WriteLine($"Your activation key is: {rawActivationKey}");