int n = int.Parse(Console.ReadLine());
int sum = 0;
int max = int.MinValue;
int allNumNegative = 0;

for (int i = 1; i <= n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    sum += currentNumber;
    if (currentNumber > max)
    {
        max = currentNumber;
    }
    if (currentNumber < 0)
    {
        allNumNegative++;
    }

}
int diff = 0;
if (allNumNegative == n)
{
    Console.WriteLine("No");
    diff = sum + max * -1;
    Console.WriteLine("Diff = " + Math.Abs(diff + max * -1));
}
else if (allNumNegative != n)
{
    diff = sum - max;

    if (diff == max)
    {
        Console.WriteLine("Yes");
        Console.WriteLine("Sum = " + max);
    }
    else
    {
        Console.WriteLine("No");
        Console.WriteLine("Diff = " + Math.Abs(diff - max));
    }
}
