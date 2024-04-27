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




//2
int[] intRange = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] numbers = null;

numbers = Enumerable.Range(intRange[0], intRange[1] - intRange[0] + 1).ToArray();

Predicate<int> predicate = num => true;

string filterWord = Console.ReadLine();

if (filterWord == "odd")
{
    predicate = num => num % 2 != 0;
}
else
{
    predicate = num => num % 2 == 0;
}

//Option1
//numbers = numbers.Where(num => predicate(num)).ToArray();

//Option2
numbers = numbers.Where(predicate.Invoke).ToArray();

Console.WriteLine(String.Join(" ", numbers));