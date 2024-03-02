int number = Math.Abs(int.Parse(Console.ReadLine()));

int evensSum = GetSumOfEvenDigits(number);
int oddsSum = GetSumOfOddDigits(number);

int result = GetMultipleOfEvenAndOdds(evensSum, oddsSum);

Console.WriteLine(result);

static int GetMultipleOfEvenAndOdds(int evens, int odds)
{
    return evens * odds;
}

static int GetSumOfEvenDigits(int number)
{
    int evens = 0;

    while (number > 0)
    {
        int lastDigit = number % 10;

        if (lastDigit % 2 == 0)
        {
            evens += lastDigit;
        }

        number /= 10;
    }

    return evens;
}

static int GetSumOfOddDigits(int number)
{
    int odds = 0;

    while (number > 0)
    {
        int lastDigit = number % 10;

        if (lastDigit % 2 == 1)
        {
            odds += lastDigit;
        }

        number /= 10;
    }

    return odds;
}