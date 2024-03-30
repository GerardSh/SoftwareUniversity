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
        string casing = commands[1];
        int startIndx = int.Parse(commands[2]);
        int endIndx = int.Parse(commands[3]);
        int count = endIndx - startIndx;

        string temp = rawActivationKey.Substring(0, startIndx);
        temp += casing == "Lower" ? rawActivationKey.Substring(startIndx, count).ToLower() : rawActivationKey.Substring(startIndx, count).ToUpper();
        temp += rawActivationKey.Substring(endIndx);
        rawActivationKey = temp;

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




//2
using System;
using System.Text;

StringBuilder activationKey = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Generate")
{
    string[] elements = input
        .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Contains")
    {
        string substring = elements[1];

        if (activationKey.ToString().Contains(substring))
        {
            Console.WriteLine($"{activationKey} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }
    else if (command == "Flip")
    {
        string upperLower = elements[1];
        int startIndex = int.Parse(elements[2]);
        int endIndex = int.Parse(elements[3]);
        int count = endIndex - startIndex;

        string substring = activationKey.ToString().Substring(startIndex, count).ToLower();

        if (upperLower == "Upper")
        {
            substring = substring.ToUpper();
        }

        activationKey.Remove(startIndex, count);
        activationKey.Insert(startIndex, substring);

        Console.WriteLine(activationKey);
    }
    else
    {
        int startIndex = int.Parse(elements[1]);
        int endIndex = int.Parse(elements[2]);
        int count = endIndex - startIndex;

        activationKey.Remove(startIndex, count);

        Console.WriteLine(activationKey);
    }
}

Console.WriteLine($"Your activation key is: {activationKey}");