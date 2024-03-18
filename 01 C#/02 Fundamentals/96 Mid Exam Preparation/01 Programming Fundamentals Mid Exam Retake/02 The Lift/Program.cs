int people = int.Parse(Console.ReadLine());

int[] lift = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < lift.Length; i++)
{
    int wagon = lift[i];

    if (wagon < 4)
    {
        int wagonFreeCapacity = 4 - wagon;
        if (people >= wagonFreeCapacity)
        {
            people -= wagonFreeCapacity;
            lift[i] += wagonFreeCapacity;
        }
        else
        {
            lift[i] += people;
            people = 0;
        }
    }
    if (people == 0 && i == lift.Length - 1 && lift[i] == 4)
    {
        Console.WriteLine(string.Join(" ", lift));
    }
    else if (people == 0)
    {
        Console.WriteLine($"The lift has empty spots!");
        Console.WriteLine(string.Join(" ", lift));
        break;
    }
    else if (i == lift.Length - 1)
    {
        Console.WriteLine($"There isn't enough space! {people} people in a queue!");
        Console.WriteLine(string.Join(" ", lift));
    }
}