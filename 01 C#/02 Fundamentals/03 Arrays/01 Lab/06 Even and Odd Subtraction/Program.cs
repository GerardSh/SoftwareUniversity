int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int evenSum = 0;
int oddSum = 0;

foreach (int i in arr)
{
    if (i % 2 == 0)
    {
        evenSum += i;
    }
    else
    {
        oddSum += i;
    }
}

Console.WriteLine(evenSum - oddSum);