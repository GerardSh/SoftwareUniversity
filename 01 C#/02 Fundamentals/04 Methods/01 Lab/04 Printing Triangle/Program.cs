int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    PrintingTriangle(1, i);
}

for (int i = n - 1; i >= 0; i--)
{
    PrintingTriangle(1, i);
}


static void PrintingTriangle(int start, int end)
{
    for (int j = start; j <= end; j++)
    {
        Console.Write(j + " ");
    }

    Console.WriteLine();
}

////2
//int n = int.Parse(Console.ReadLine());
//int count = 1;
//bool isHalf = false;

//for (int i = 0; i < n * 2 - 1; i++)
//{
//    MyMethod(1, count);

//    if (i == n - 1)
//    {
//        isHalf = true;
//    }

//    if (!isHalf)
//    {
//        count++;
//    }
//    else
//    {
//        count--;
//    }

//    Console.WriteLine();
//}

//static void MyMethod(int start, int end)
//{
//    for (int i = start; i <= end; i++)
//    {
//        Console.Write(i + " ");
//    }
//}

////3 without a method
//for (int row = 1; row <= n * 2 - 1; row++)
//{
//    if (row <= n)
//    {
//        for (int col = 1; col <= row; col++)
//        {
//            Console.Write(col + " ");
//        }
//    }
//    else
//    {
//        for (int col = 1; col <= countReverse; col++)
//        {
//            Console.Write(col + " ");
//        }

//        countReverse--;
//    }
//    Console.WriteLine();
//}

////4
//int n = int.Parse(Console.ReadLine());

//PrintingTopLevel(1, n, "+");
//PrintingTopLevel(n - 1, 0, "-");

//static void PrintingTopLevel(int start, int end, string count)
//{
//    for (int i = start; count == "+" && i <= end || count == "-" && i > end; i += count == "+" ? 1 : -1)
//    {
//        PrintingTriangle(1, i);
//    }
//}

//static void PrintingTriangle(int start, int end)
//{
//    for (int j = start; j <= end; j++)
//    {
//        Console.Write(j + " ");
//    }

//    Console.WriteLine();
//}