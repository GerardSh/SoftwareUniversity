using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string input;

        while ((input = Console.ReadLine()) != "Done")
        {
            var match = Regex.Match(input, @"<([A-Z][a-zA-Z ]+)>.{0,}&&([A-Z]{2}[\d]{4}[A-Z]{2})&{2}");

            if (!match.Success)
            {
                continue;
            }

            var carModel = match.Groups[1].Value;
            var carNumer = match.Groups[2].Value;

            Console.WriteLine($"Linked car {carModel} with number {carNumer}!");
        }
    }
}

// Created on: 05 / 12 / 2024 09:23:22