using System.Text.RegularExpressions;

MatchCollection matches = Regex.Matches(Console.ReadLine(), @"([#\|])(?<name>[A-Za-z\s]+)\1(?<expiration>\d{2}/\d{2}/\d{2})\1(?<nutrition>\d+)\1");

int sumNutrition = 0;

List<string> items = new List<string>();

foreach (Match match in matches)
{
    sumNutrition += int.Parse(match.Groups["nutrition"].Value);

    items.Add($"Item: {match.Groups["name"]}, Best before: {match.Groups["expiration"]}, Nutrition: {match.Groups["nutrition"].Value}");
}

Console.WriteLine($"You have food to last you for: {sumNutrition / 2000} days!");
Console.WriteLine(string.Join("\n", items));




//2
using System.Text.RegularExpressions;

MatchCollection matches = Regex.Matches(Console.ReadLine(), @"([#\|])(?<name>[A-Za-z\s]+)\1(?<expiration>\d{2}/\d{2}/\d{2})\1(?<nutrition>\d+)\1");

int sumNutrition = matches.Sum(x => int.Parse(x.Groups["nutrition"].Value));

Console.WriteLine($"You have food to last you for: {sumNutrition / 2000} days!");

foreach (Match match in matches)
{
    Console.WriteLine($"Item: {match.Groups["name"]}, Best before: {match.Groups["expiration"]}, Nutrition: {match.Groups["nutrition"].Value}");
}