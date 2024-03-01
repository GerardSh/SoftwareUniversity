string number = Console.ReadLine();

int totalSum = 0;

for (int i = 0; i < number.Length; i++)
{
    int firstChar = int.Parse(number[i].ToString());
    int sum = 1;

    for (int j = 1; j <= firstChar; j++)
    {
        sum = sum * j;
    }

    totalSum += sum;
}

if (totalSum == int.Parse(number))
{
    Console.WriteLine("yes");
}
else
{
    Console.WriteLine("no");
}