using System.Text.RegularExpressions;

string text = Console.ReadLine();

Regex regex = new Regex(@"\s[a-z][\w.\-]+\w@\w[\w.\-]*\w\.\w{2,15}");

foreach (Match match in regex.Matches(text))
{
    if (match.Success)
    {
        string email = match.Value.Trim();

        Console.WriteLine(email);
    }
}