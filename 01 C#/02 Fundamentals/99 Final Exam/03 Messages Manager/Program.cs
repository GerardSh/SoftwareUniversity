using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string password = Console.ReadLine();

    Match match = Regex.Match(password, @"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$");

    if (!match.Success)
    {
        Console.WriteLine("Try another password!");
        continue;
    }

    password = match.Groups[2].Value + match.Groups[3].Value + match.Groups[4].Value + match.Groups[5].Value;

    Console.WriteLine($"Password: {password}");
}