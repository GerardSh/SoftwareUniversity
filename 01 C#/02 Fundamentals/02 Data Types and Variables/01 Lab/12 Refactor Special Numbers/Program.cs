int number = int.Parse(Console.ReadLine());

for (int i = 1; i <= number; i++)
{
    int originalNumber = i;
    bool isFound;
    int sum = 0;

    while (originalNumber > 0)
    {
        sum += originalNumber % 10;
        originalNumber /= 10;
    }

    isFound = (sum == 5) || (sum == 7) || (sum == 11);
    Console.WriteLine("{0} -> {1}", i, isFound);
}