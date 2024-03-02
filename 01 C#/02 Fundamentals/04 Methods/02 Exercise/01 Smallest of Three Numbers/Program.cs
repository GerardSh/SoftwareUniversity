int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int number3 = int.Parse(Console.ReadLine());

int smallestNumber = FindSmallestNumber(number1, number2, number3);

Console.WriteLine(smallestNumber);

static int FindSmallestNumber(int num1, int num2, int num3)
{
    int smallestNumber = num1;

    if (num2 < num1)
    {
        smallestNumber = num2;
    }

    if (num3 < smallestNumber)
    {
        smallestNumber = num3;
    }
    return smallestNumber;
}