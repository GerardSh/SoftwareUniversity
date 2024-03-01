const int capacity = 255;

int n = int.Parse(Console.ReadLine());
int sum = 0;

for (int i = 0; i < n; i++)
{
    int currentLiters = int.Parse(Console.ReadLine());

    if (currentLiters + sum > capacity)
    {
        Console.WriteLine("Insufficient capacity!");
    }
    else
    {
        sum += currentLiters;
    }
}

Console.WriteLine(sum);