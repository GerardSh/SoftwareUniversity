int[] intRange = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

string OddOrEven = Console.ReadLine();

Predicate<int> predicate = x => true;

switch (OddOrEven)
{
    case "odd":
        predicate = x => x % 2 != 0;
        break;

    default:
        predicate = x => x % 2 == 0;
        break;
}

int lowerRange = intRange[0];
int upperRange = intRange[1];

for (int i = lowerRange; i <= upperRange; i++)
{
    if (predicate(i))
    {
        Console.Write(i + " ");
    }
}