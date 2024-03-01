int n = int.Parse(Console.ReadLine());
decimal sum = 0;

for (int i = 0; i < n; i++)
{
    decimal number = decimal.Parse(Console.ReadLine());

    if (number == 0)
    {
        i--;
    }

    sum += number;
}

Console.WriteLine(sum);