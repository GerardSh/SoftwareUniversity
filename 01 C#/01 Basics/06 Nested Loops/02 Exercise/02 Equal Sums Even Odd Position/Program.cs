int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());

for (int i = n1; i <= n2; i++)
{
    int num = i;
    int sum = 0;
    int sum2 = 0;
    int position = 0;
    while (num > 0)
    {
        int digit = num % 10;
        num /= 10;
        if (position % 2 == 0)
        {
            sum += digit;
        }
        else
        {
            sum2 += digit;
        }
        position++;
    }
    if (sum == sum2)
    {
        Console.Write(i + " ");
    }
}




//2
int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());

for (int i = n1; i <= n2; i++)
{
    string currentNumber = i.ToString();
    int sum = 0;
    int sum2 = 0;

    for (int j = 0; j < currentNumber.Length; j++)
    {
        int digit = int.Parse(currentNumber[j].ToString());
        if (j % 2 == 0)
        {
            sum += digit;
        }
        else
        {
            sum2 += digit;
        }
    }
    if (sum == sum2)
    {
        Console.Write(i + " ");
    }
}