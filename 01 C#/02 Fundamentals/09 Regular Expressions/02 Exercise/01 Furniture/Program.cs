using System.Text.RegularExpressions;

string input;
double totalSum = 0;

MatchCollection matches;

Console.WriteLine("Bought furniture:");

while ((input = Console.ReadLine()) != "Purchase")
{
    Match match = Regex.Match(input, @">+(?<furniture>[A-Z][A-Za-z]+)<+(?<price>\d+\.?(\d+)*)!(?<quantity>\d+)");

    if (match.Success)
    {
        Console.WriteLine(match.Groups["furniture"]);
        totalSum += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
    }
}

Console.WriteLine($"Total money spend: {totalSum:f2}");