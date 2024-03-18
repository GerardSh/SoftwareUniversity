int health = 100;
int bitcoins = 0;
bool alive = true;

string[] dungeonRooms = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < dungeonRooms.Length; i++)
{
    string[] roomData = dungeonRooms[i].Split(" ");

    string name = roomData[0];
    int number = int.Parse(roomData[1]);

    if (name == "potion")
    {
        int amount = 0;

        if (health + number > 100)
        {
            amount = 100 - health;
        }
        else
        {
            amount = number;
        }

        health += amount;

        Console.WriteLine($"You healed for {amount} hp.");
        Console.WriteLine($"Current health: {health} hp.");
    }
    else if (name == "chest")
    {
        bitcoins += number;

        Console.WriteLine($"You found {number} bitcoins.");
    }
    else
    {
        health -= number;

        if (health <= 0)
        {
            Console.WriteLine($"You died! Killed by {name}.");
            Console.WriteLine($"Best room: {i + 1}");

            alive = false;
            break;
        }
        else
        {
            Console.WriteLine($"You slayed {name}.");
        }
    }
}

if (alive)
{
    Console.WriteLine("You've made it!");
    Console.WriteLine($"Bitcoins: {bitcoins}");
    Console.WriteLine($"Health: {health}");
}