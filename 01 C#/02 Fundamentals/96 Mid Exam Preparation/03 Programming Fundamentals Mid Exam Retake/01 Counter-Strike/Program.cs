int energy = int.Parse(Console.ReadLine());
int wonGamesCount = 0;
int gamesCount = 0;

string input;

while ((input = Console.ReadLine()) != "End of battle")
{
    gamesCount++;

    int distance = int.Parse(input);

    if (energy >= distance)
    {
        energy -= distance;
        wonGamesCount++;
    }
    else
    {
        Console.WriteLine($"Not enough energy! Game ends with {wonGamesCount} won battles and {energy} energy");
        return;
    }

    if (gamesCount % 3 == 0)
    {
        energy += wonGamesCount;
    }
}

Console.WriteLine($"Won battles: {wonGamesCount}. Energy left: {energy}");