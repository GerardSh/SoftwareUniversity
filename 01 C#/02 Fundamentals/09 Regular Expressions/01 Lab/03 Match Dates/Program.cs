using System.Text.RegularExpressions;

string input = Console.ReadLine();

MatchCollection dates = Regex.Matches(input, @"\b(?<day>\d{2})(\/|-|.)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

foreach (Match date in dates)
{
    Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
}