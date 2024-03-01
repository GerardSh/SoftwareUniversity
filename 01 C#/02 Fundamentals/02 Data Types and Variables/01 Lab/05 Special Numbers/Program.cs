int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    bool isTrue = false;
    int number = i;
    int digitSum = 0;

    while (number > 0)
    {
        digitSum += number % 10;
        number /= 10;
    }

    if (digitSum == 5 || digitSum == 7 || digitSum == 11)
    {
        isTrue = true;
    }

    Console.WriteLine($"{i} -> {isTrue}");
}