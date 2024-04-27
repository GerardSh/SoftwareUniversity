int n = int.Parse(Console.ReadLine());

var numbers = Enumerable.Range(1, n).ToArray();

var divisors = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Func<int[], int, bool> isDivisible = (divisors, number) =>
{
    foreach (int divisor in divisors)
    {
        if (number % divisor != 0)
        {
            return false;
        }
    }

    return true;
};

Action<int> printAction = number => Console.Write(number + " ");

numbers.Where(number => isDivisible(divisors, number)).ToList().ForEach(printAction);