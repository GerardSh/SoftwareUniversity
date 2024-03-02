int n = int.Parse(Console.ReadLine());

int num1 = 0;
int num2 = 0;
int num3 = 1;
int sum = 0;

if (n == 1)
{
    Console.WriteLine(n);
}
else
{
    Console.Write(1);
    for (int i = 0; i < n - 1; i++)
    {
        Console.Write(" " + (num1 + num2 + num3));
        sum = num1 + num2 + num3;

        num1 = num2;
        num2 = num3;
        num3 = sum;
    }
}

//2
int n = int.Parse(Console.ReadLine());

int[] array = GetTribonacciSequence(n);

PrintTribonacciSequence(array);

static void PrintTribonacciSequence(int[] array)
{
    Console.WriteLine(string.Join(" ", array));
}

static int[] GetTribonacciSequence(int n)
{
    int num1 = 0;
    int num2 = 0;
    int num3 = 1;
    int sum = 0;

    int[] array = new int[n];

    array[0] = 1;

    for (int i = 1; i <= n - 1; i++)
    {
        array[i] = (num1 + num2 + num3);
        sum = num1 + num2 + num3;

        num1 = num2;
        num2 = num3;
        num3 = sum;
    }

    return array;
}