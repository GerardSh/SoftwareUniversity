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




//3
using System.Text.RegularExpressions;

string text = Console.ReadLine();

MatchCollection matches = Regex.Matches(text, @"(#|\|)([a-zA-Z\s]+)\1(\d\d\/\d\d\/\d\d)\1([0-99999]{1,5}|100000)\1");

int calories = matches.Sum(x => int.Parse(x.Groups[4].Value));

Console.WriteLine($"You have food to last you for: {calories / 2000} days!");

foreach (Match match in matches)
{
    string item = match.Groups[2].Value;
    string date = match.Groups[3].Value;
    int nutrition = int.Parse(match.Groups[4].Value);

    Console.WriteLine($"Item: {item}, Best before: {date}, Nutrition: {nutrition}");
}