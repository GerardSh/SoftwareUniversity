using System.Text;
using System.Text.RegularExpressions;

string text = Console.ReadLine().ToUpper();

MatchCollection matches = Regex.Matches(text, @"(?<symbols>[^0-9]+)(?<numbers>\d+)");

StringBuilder rageQuitText = new StringBuilder();

foreach (Match match in matches)
{
    int repetitions = int.Parse(match.Groups["numbers"].Value);

    for (int i = 0; i < repetitions; i++)
    {
        rageQuitText.Append(match.Groups["symbols"].Value);
    }
}

Console.WriteLine($"Unique symbols used: {rageQuitText.ToString().Distinct().Count()}");
Console.WriteLine(rageQuitText);