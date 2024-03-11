using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
List<string> attackedPlanets = new List<string>();
List<string> destroyedPlanets = new List<string>();

for (int i = 0; i < n; i++)
{
    string encryptedMessage = Console.ReadLine();
    int decryptionKey = Regex.Matches(encryptedMessage, "[sStTaArR]").Count;
    StringBuilder decryptedMessage = new StringBuilder();

    foreach (char c in encryptedMessage)
    {
        decryptedMessage.Append((char)(c - decryptionKey));
    }

    Match planet = Regex.Match(decryptedMessage.ToString(), @"@(?<planet>[A-Za-z]+)[^@\-!:>]*?:(?<population>\d+)[^@\-!:>]*?!(?<type>[AD])![^@\-!:>]*?->(?<soldiers>\d+)");

    if (planet.Success)
    {
        if (planet.Groups["type"].Value == "A")
        {
            attackedPlanets.Add(planet.Groups["planet"].Value);
        }
        else if (planet.Groups["type"].Value == "D")
        {
            destroyedPlanets.Add(planet.Groups["planet"].Value);
        }
    }
}

Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
PrintPlanetNames(attackedPlanets);

Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
PrintPlanetNames(destroyedPlanets);

static void PrintPlanetNames(List<string> planets)
{
    foreach (string planet in planets.OrderBy(x => x))
    {
        Console.WriteLine($"-> {planet}");
    }
}