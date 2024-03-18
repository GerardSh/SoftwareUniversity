using System.Linq;

List<int> neighborhood = Console.ReadLine()
    .Split("@", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int lastPosition = 0;

string input;

while ((input = Console.ReadLine()) != "Love!")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    int indx = int.Parse(commands[1]) + lastPosition;

    if (indx >= neighborhood.Count)
    {
        indx = 0;
    }

    lastPosition = indx;

    if (neighborhood[indx] == 0)
    {
        Console.WriteLine($"Place {indx} already had Valentine's day.");
        continue;
    }

    neighborhood[indx] -= 2;

    if (neighborhood[indx] == 0)
    {
        Console.WriteLine($"Place {indx} has Valentine's day.");
    }
}

Console.WriteLine($"Cupid's last position was {lastPosition}.");

if (neighborhood.Sum() == 0)
{
    Console.WriteLine("Mission was successful.");
}
else
{
    Console.WriteLine($"Cupid has failed {neighborhood.Where(x => x > 0).Count()} places.");
}