string[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => $"{double.Parse(x) * 1.20:f2}")
    .ToArray();

Console.WriteLine(string.Join("\n", prices));