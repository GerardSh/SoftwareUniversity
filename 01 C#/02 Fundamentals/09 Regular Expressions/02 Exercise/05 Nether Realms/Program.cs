using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

List<string> demons = Regex.Split(Console.ReadLine(), @"[, ]+ ").ToList();
Dictionary<string, KeyValuePair<int, double>> healthAndDamageByDemon = new Dictionary<string, KeyValuePair<int, double>>();

Regex healthRegex = new Regex(@"[^0-9+\-*/.]");
Regex damageRegex = new Regex(@"(?:[-+]?\d+\.?\d*|[*/])");

foreach (string demon in demons)
{
    MatchCollection healthMatches = healthRegex.Matches(demon);
    int health = 0;

    foreach (Match match in healthMatches)
    {
        health += char.Parse(match.Value);
    }

    MatchCollection damageMatches = damageRegex.Matches(demon);
    double damage = 0;

    foreach (Match match in damageMatches)
    {
        if (match.Value != "/" && match.Value != "*")
        {
            damage += double.Parse(match.Value);
        }
    }

    foreach (Match match in damageMatches)
    {
        if (match.Value == "/")
        {
            damage /= 2;
        }
        else if (match.Value == "*")
        {
            damage *= 2;
        }
    }

    healthAndDamageByDemon.Add(demon, new KeyValuePair<int, double>(health, damage));
}

foreach (KeyValuePair<string, KeyValuePair<int, double>> demon in healthAndDamageByDemon.OrderBy(x => x.Key))
{
    Console.WriteLine($"{demon.Key} - {demon.Value.Key} health, {demon.Value.Value:f2} damage");
}