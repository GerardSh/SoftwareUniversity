using System.Text.RegularExpressions;

string input = Console.ReadLine();

MatchCollection locationMatches = Regex.Matches(input, @"([=/])([A-Z][A-Za-z]{2,})\1");

int sumLength = locationMatches
    .Select(x => x.Groups[2].Length)
    .Sum();

List<string> locations = new List<string>();

foreach (Match match in locationMatches)
{
    locations.Add(match.Groups[2].Value);
}

Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
Console.WriteLine($"Travel Points: {sumLength}");