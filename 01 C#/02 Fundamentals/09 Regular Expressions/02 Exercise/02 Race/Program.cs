using System.Text;
using System.Text.RegularExpressions;

string[] names = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

Regex regexName = new Regex(@"[A-Za-z]");
Regex regexDistance = new Regex(@"\d");

Dictionary<string, double> racers = new Dictionary<string, double>();

string input;

while ((input = Console.ReadLine()) != "end of race")
{

    StringBuilder name = new StringBuilder();
    double distance = 0;

    foreach (char c in input)
    {
        Match matchName = regexName.Match(c.ToString());
        Match matchDistance = regexDistance.Match(c.ToString());
        name = name.Append(regexName.Match(c.ToString()).Value);

        if (matchDistance.Success)
        {
            distance += double.Parse(matchDistance.Value);
        }
    }

    if (!racers.ContainsKey(name.ToString()))
    {
        racers.Add(name.ToString(), 0);
    }

    racers[name.ToString()] += distance;
}

foreach (string racer in racers.Keys)
{
    if (!names.Contains(racer))
    {
        racers.Remove(racer);
    }
}

racers = racers
    .OrderByDescending(x => x.Value)
    .Take(3)
    .ToDictionary(x => x.Key, x => x.Value);

int count = 1;

foreach (string racer in racers.Keys)
{
    if (count == 1)
    {
        Console.WriteLine($"1st place: {racer}");
        count++;
    }
    else if (count == 2)
    {
        Console.WriteLine($"2nd place: {racer}");
        count++;
    }
    else
    {
        Console.WriteLine($"3rd place: {racer}");
    }
}




//2
using System.Text;
using System.Text.RegularExpressions;

Dictionary<string, int> distanceByRacer = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToDictionary(x => x, x => 0);

Regex lettersRegex = new Regex(@"[A-Za-z]+");
Regex digitsRegex = new Regex(@"\d");

string input;

while ((input = Console.ReadLine()) != "end of race")
{
    MatchCollection names = lettersRegex.Matches(input);

    StringBuilder nameBuilder = new StringBuilder();

    foreach (Match match in names)
    {
        nameBuilder = nameBuilder.Append(match.Value);
    }

    string name = nameBuilder.ToString();
    int distanceSum = 0;

    if (distanceByRacer.ContainsKey(name))
    {
        MatchCollection distance = digitsRegex.Matches(input);

        foreach (Match match in distance)
        {
            distanceSum += int.Parse(match.Value);
        }

        distanceByRacer[name] += distanceSum;
    }
}

string[] topRacers = distanceByRacer
    .OrderByDescending(x => x.Value)
    .Select(x => x.Key)
    .Take(3)
    .ToArray();

Console.WriteLine($"1st place: {topRacers[0]}");
Console.WriteLine($"2nd place: {topRacers[1]}");
Console.WriteLine($"3rd place: {topRacers[2]}");