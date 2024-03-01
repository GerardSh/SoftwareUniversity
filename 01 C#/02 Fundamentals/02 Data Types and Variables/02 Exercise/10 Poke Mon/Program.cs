int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
short y = short.Parse(Console.ReadLine());
int nOriginalValue = n;

int targetCount = 0;

while (n >= m)
{
    n -= m;
    targetCount++;

    if (n == n / 2.0 && y != 0)
    {
        n /= y;
    }
}

Console.WriteLine(n);
Console.WriteLine(targetCount);