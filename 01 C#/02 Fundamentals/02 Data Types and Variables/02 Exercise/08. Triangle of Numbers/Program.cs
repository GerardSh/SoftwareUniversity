int n = int.Parse(Console.ReadLine());

int number = 1;

int column = 1;
int rows = 1;

for (int i = 1; number <= n; i++)
{
    if (column == rows)
    {
        Console.WriteLine(number);
        number++;
        column = 1;
        rows++;
    }
    else
    {
        Console.Write(number + " ");
        column++;
    }
}

//Variant 2

//for (int i = 1; i <= n; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {
//        Console.Write(number + " ");
//    }

//    number++;
//    Console.WriteLine();
//}