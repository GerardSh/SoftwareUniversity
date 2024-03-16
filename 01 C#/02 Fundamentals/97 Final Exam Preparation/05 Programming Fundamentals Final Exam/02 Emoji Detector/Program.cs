using System.Text.RegularExpressions;

string input = Console.ReadLine();
var digitMatches = Regex.Matches(input, @"[\d]");

ulong coolThreshold = 1;
Console.WriteLine();
foreach (Match match in digitMatches)
{
    coolThreshold *= ulong.Parse(match.Value);
}

var emojiMatches = Regex.Matches(input, @"(:{2}|\*{2})([A-Z][a-z]{2,})\1");

Console.WriteLine($"Cool threshold: {coolThreshold}");
Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

foreach (Match match in emojiMatches)
{
    string emoji = match.Groups[2].Value;
    ulong emojiSum = 0;

    foreach (char c in emoji)
    {
        emojiSum += c;
    }

    if (emojiSum > coolThreshold)
    {
        Console.WriteLine(match.Value);
    }
}