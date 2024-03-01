int n = int.Parse(Console.ReadLine());

for (int i = 1111; i < 10000; i++)
{
    int countDigits = 0;
    int currentNumber = i;

    for (int j = 0; j < 4; j++)
    {
        int digit = currentNumber % 10;
        currentNumber /= 10;

        if (digit == 0)
        {
            break;
        }
        else if (n % digit == 0)
        {
            countDigits++;
        }
    }

    if (countDigits == 4)
    {
        Console.Write(i + " ");
    }
}

//Variant 2

//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= 9; i++)
//{

//    if (n % i != 0)
//    {
//        continue;
//    }

//    for (int i2 = 1; i2 <= 9; i2++)
//    {

//        if (n % i2 != 0)
//        {
//            continue;
//        }

//        for (int i3 = 1; i3 <= 9; i3++)
//        {
//            if (n % i3 != 0)
//            {
//                continue;
//            }

//            for (int i4 = 1; i4 <= 9; i4++)
//            {
//                if (n % i4 == 0)
//                {
//                    Console.Write($"{i}{i2}{i3}{i4} ");
//                }
//            }
//        }
//    }
//}