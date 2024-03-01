int n = int.Parse(Console.ReadLine());
double p1 = 0; double p2 = 0;
double p3 = 0; double p4 = 0;
double p5 = 0;

for (int i = 1; i <= n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    if (currentNumber < 200)
    {
        p1 += 1;
    }
    else if (currentNumber < 400)
    {
        p2 += 1;
    }
    else if (currentNumber < 600)
    {
        p3 += 1;
    }
    else if (currentNumber < 800)
    {
        p4 += 1;
    }
    else
    {
        p5 += 1;
    }
}
Console.WriteLine($"{p1 / n * 100:f2}%");
Console.WriteLine($"{p2 / n * 100:f2}%");
Console.WriteLine($"{p3 / n * 100:f2}%");
Console.WriteLine($"{p4 / n * 100:f2}%");
Console.WriteLine($"{p5 / n * 100:f2}%");