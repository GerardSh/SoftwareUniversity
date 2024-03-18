List<int> pirateShip = Console.ReadLine()
    .Split(">", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> warShip = Console.ReadLine()
    .Split(">", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int healthCapacity = int.Parse(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Retire")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "Fire")
    {
        int index = int.Parse(commands[1]);
        int damage = int.Parse(commands[2]);

        if (validIndex(index, warShip))
        {
            warShip[index] -= damage;

            if (warShip[index] <= 0)
            {
                Console.WriteLine("You won! The enemy ship has sunken.");
                return;
            }
        }
    }
    else if (command == "Defend")
    {
        int startIndex = int.Parse(commands[1]);
        int endIndex = int.Parse(commands[2]);
        int damage = int.Parse(commands[3]);

        if (validIndex(startIndex, pirateShip) && validIndex(endIndex, pirateShip))
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                pirateShip[i] -= damage;

                if (pirateShip[i] <= 0)
                {
                    Console.WriteLine("You lost! The pirate ship has sunken.");
                    return;
                }
            }
        }
    }
    else if (command == "Repair")
    {
        int index = int.Parse(commands[1]);
        int health = int.Parse(commands[2]);

        if (validIndex(index, pirateShip))
        {
            pirateShip[index] += health;

            if (pirateShip[index] > healthCapacity)
            {
                pirateShip[index] = healthCapacity;
            }
        }
    }
    else
    {
        int sectionCount = pirateShip
            .Where(x => x < healthCapacity * 0.20)
            .Count();

        Console.WriteLine($"{sectionCount} sections need repair.");
    }
}

Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
Console.WriteLine($"Warship status: {warShip.Sum()}");

static bool validIndex(int index, List<int> ship)
{
    if (index >= 0 && index < ship.Count)
    {
        return true;
    }
    else
    {
        return false;
    }
}