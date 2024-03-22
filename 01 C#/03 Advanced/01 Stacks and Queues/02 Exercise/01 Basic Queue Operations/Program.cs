int[] initialNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = initialNumbers[0];
int s = initialNumbers[1];
int x = initialNumbers[2];

int[] numbersToAdd = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> numbers = new Queue<int>(numbersToAdd.Take(n));

for (int i = 0; i < s; i++)
{
    numbers.Dequeue();
}

if (numbers.Count > 0)
{
    if (numbers.Contains(x))
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine(numbers.Min());
    }
}
else
{
    Console.WriteLine(0);
}