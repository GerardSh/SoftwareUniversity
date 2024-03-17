using System.Text.RegularExpressions;

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, @"([@#])([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1");

if (matches.Count == 0)
{
    Console.WriteLine("No word pairs found!");
}
else
{
    Console.WriteLine($"{matches.Count} word pairs found!");
}

List<string> mirrorPairs = new List<string>();

foreach (Match match in matches)
{
    string wordOne = match.Groups[2].Value;
    string wordTwo = match.Groups[3].Value;
    string wordTwoReversed = string.Concat(match.Groups[3].Value.Reverse());

    if (wordOne == wordTwoReversed)
    {
        mirrorPairs.Add($"{wordOne} <=> {wordTwo}");
    }
}

if (mirrorPairs.Count == 0)
{
    Console.WriteLine("No mirror words!");
}
else
{
    Console.WriteLine($"The mirror words are:\n{string.Join(", ", mirrorPairs)}");
}