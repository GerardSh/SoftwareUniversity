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




//2
int health = 100;
int bitcoins = 0;
int bestRoom = 1;

string[] dungeonRooms = Console.ReadLine().Split("|");

for (int i = 0; i < dungeonRooms.Length; i++)
{
    string[] room = dungeonRooms[i].Split(" ");

    string command = room[0];
    int number = int.Parse(room[1]);

    if (command == "potion")
    {

        if (number + health <= 100)
        {
            health += number;
        }
        else
        {
            number -= health + number - 100;
            health = 100;
        }

        Console.WriteLine($"You healed for {number} hp.");
        Console.WriteLine($"Current health: {health} hp.");
    }
    else if (command == "chest")
    {
        bitcoins += number;
        Console.WriteLine($"You found {number} bitcoins.");
    }
    else
    {
        if (number >= health)
        {
            Console.WriteLine($"You died! Killed by {command}.");
            Console.WriteLine($"Best room: {bestRoom}");
            return;
        }
        else
        {
            Console.WriteLine($"You slayed {command}.");
            health -= number;
        }
    }

    bestRoom++;
}

Console.WriteLine($"You've made it!");
Console.WriteLine($"Bitcoins: {bitcoins}");
Console.WriteLine($"Health: {health}");