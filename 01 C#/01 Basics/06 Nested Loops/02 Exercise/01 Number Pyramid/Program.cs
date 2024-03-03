int n = int.Parse(Console.ReadLine());
int n2 = 1;
int n3 = 1;

while (n3 <= n)
{
    for (int j = 1; j <= n2; j++)
    {
        Console.Write(n3 + " ");
        if (n3 < n)
        {
            n3++;
        }
        else
        {
            return;
        }
    }
    Console.WriteLine();
    n2++;
}




//2
int n = int.Parse(Console.ReadLine());

int digits = 1;

bool stop = false;

for (int rows = 1; rows <= n; rows++)
{
    for (int col = 1; col <= rows; col++)
    {
        if (digits > n)
        {
            stop = true;
            break;
        }
        Console.Write(digits + " ");
        digits++;

    }
    if (stop)
    {
        break;
    }
    Console.WriteLine();
}