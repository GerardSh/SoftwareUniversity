int n = int.Parse(Console.ReadLine());


for (int i = 1; i <= n; i++)
{
    int digitSum = SumDigits(i);

    if (isDivisible(digitSum) && HasOddDigit(i))
    {
        Console.WriteLine(i);
    }
}


bool HasOddDigit(int numb)
{
    while (numb > 0)
    {
        int temp = numb % 10;
        numb = numb / 10;

        if (temp % 2 == 1)
        {
            return true;
        }
    }

    return false;
}

static bool isDivisible(int numb)
{
    if (numb % 8 == 0)
    {
        return true;
    }

    return false;
}

static int SumDigits(int numb)
{
    int sum = 0;

    while (numb > 0)
    {
        sum += numb % 10;
        numb = numb / 10;
    }

    return sum;
}