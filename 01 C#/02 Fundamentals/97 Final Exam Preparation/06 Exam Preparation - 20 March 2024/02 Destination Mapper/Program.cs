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




//2
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

MatchCollection locations = Regex.Matches(Console.ReadLine(), @"(=|\/)([A-Z][A-Za-z]{2,})\1");

int travelPoints = locations.Sum(p => p.Groups[2].Length);

List<string> cities = locations.Select(x => x.Groups[2].Value).ToList();

Console.WriteLine($"Destinations: {string.Join(", ", cities)}");
Console.WriteLine($"Travel Points: {travelPoints}");