int[] initialArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

string[] input;

while ((input = Console.ReadLine().Split())[0] != "end")
{
    string command = input[0];

    if (command == "exchange")
    {
        int index = int.Parse(input[1]);

        IndexExchange(initialArray, index);
    }
    else if (command == "max" || command == "min")
    {
        string evenOrOdd = input[1];
        string maxOrMin = input[0];

        MaxMinEvenOddIndexCheck(initialArray, maxOrMin, evenOrOdd);
    }
    else if (command == "first" || command == "last")
    {
        string firstLast = input[0];
        int count = int.Parse(input[1]);
        string evenOrOdd = input[2];

        FirstLastEvenOdd(initialArray, firstLast, count, evenOrOdd);
    }
}
if (initialArray.Length > 0)
{
    Console.WriteLine($"[{string.Join(", ", initialArray)}]");
}

static void FirstLastEvenOdd(int[] array, string firstLast, int count, string evenOrOdd)
{
    if (count > array.Length)
    {
        Console.WriteLine("Invalid count");

        return;
    }

    int evensInArray = 0;
    int oddsInArray = 0;

    foreach (int i in array)
    {
        if (i % 2 == 0)
        {
            evensInArray++;
        }
        else
        {
            oddsInArray++;
        }
    }

    int[] arrayEvens = new int[evensInArray];
    int[] arrayOdds = new int[oddsInArray];
    int evensIndex = 0;
    int oddsIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 == 0)
        {
            arrayEvens[evensIndex] = array[i];
            evensIndex++;
        }
        else
        {
            arrayOdds[oddsIndex] = array[i];
            oddsIndex++;
        }
    }

    if (firstLast == "last")
    {
        if (evenOrOdd == "even")
        {
            PrintArrayCountLast(arrayEvens, count);
        }
        else
        {
            PrintArrayCountLast(arrayOdds, count);
        }
    }
    else if (firstLast == "first")
    {
        if (evenOrOdd == "even")
        {
            PrintArrayCountFirst(arrayEvens, count);

        }
        else
        {
            PrintArrayCountFirst(arrayOdds, count);
        }
    }
}

static void PrintArrayCountFirst(int[] array, int count)
{
    if (array.Length == 0)
    {
        Console.WriteLine("[]");
        return;
    }

    string result = "[";

    for (int i = 0; i < array.Length && i < count; i++)
    {
        if (i + 1 == count || i + 1 == array.Length)
        {
            result += array[i] + "]";
            break;
        }
        else
        {
            result += $"{array[i]}, ";
        }
    }

    Console.WriteLine(result);
}

static void PrintArrayCountLast(int[] array, int count)
{
    if (array.Length == 0)
    {
        Console.WriteLine("[]");
        return;
    }

    int iterations = 0;
    string result = "[";

    for (int i = array.Length - count; i < array.Length && iterations < count; i++)
    {
        if (i < 0)
        {
            i = 0;
        }

        if (iterations + 1 == count || i + 1 == array.Length)
        {
            result += array[i] + "]";
            break;
        }
        else
        {
            result += $"{array[i]}, ";
        }

        iterations++;
    }

    Console.WriteLine(result);
}


static void MaxMinEvenOddIndexCheck(int[] array, string maxOrMin, string evenOrOdd)
{
    if (array.Length == 0)
    {
        return;
    }

    int maxEven = int.MinValue;
    int maxEvenIndex = 0;
    int maxOdd = int.MinValue;
    int maxOddIndex = 0;
    int minEven = int.MaxValue;
    int minEvenIndex = 0;
    int minOdd = int.MaxValue;
    int minOddIndex = 0;
    int indexCount = 0;
    int evensCount = 0;
    int oddsCount = 0;

    foreach (int i in array)
    {
        if (i % 2 == 0)
        {
            evensCount++;

            if (i >= maxEven)
            {
                maxEven = i;
                maxEvenIndex = indexCount;
            }

            if (i <= minEven)
            {
                minEven = i;
                minEvenIndex = indexCount;
            }
        }
        else if (i % 2 == 1)
        {
            oddsCount++;

            if (i >= maxOdd)
            {
                maxOdd = i;
                maxOddIndex = indexCount;
            }

            if (i <= minOdd)
            {
                minOdd = i;
                minOddIndex = indexCount;
            }
        }

        indexCount++;
    }

    if (evenOrOdd == "even" && evensCount == 0 || evenOrOdd == "odd" && oddsCount == 0)
    {
        Console.WriteLine("No matches");
        return;
    }

    if (maxOrMin == "max")
    {
        if (evenOrOdd == "even")
        {
            Console.WriteLine(maxEvenIndex);
        }
        else if (evenOrOdd == "odd")
        {
            Console.WriteLine(maxOddIndex);
        }
    }
    else if (maxOrMin == "min")
    {
        if (evenOrOdd == "even")
        {
            Console.WriteLine(minEvenIndex);
        }
        else if (evenOrOdd == "odd")
        {
            Console.WriteLine(minOddIndex);
        }
    }
}

static void IndexExchange(int[] array, int index)
{
    if (index > array.Length - 1 || index < 0)
    {
        Console.WriteLine("Invalid index");
    }
    else
    {
        for (int i = 0; i <= index; i++)
        {
            int temp = array[0];

            for (int j = 0; j < array.Length - 1; j++)
            {
                array[j] = array[j + 1];
            }

            array[array.Length - 1] = temp;
        }
    }
}

////2
//int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

//string[] input;
//int[] elements;

//while ((input = Console.ReadLine().Split())[0] != "end")
//{
//    string command = input[0];

//    if (command == "exchange")
//    {
//        int index = int.Parse(input[1]);

//        if (index < 0 || index >= numbers.Length)
//        {
//            Console.WriteLine("Invalid index");
//        }
//        else
//        {
//            ArrayIndexExchange(numbers, index);
//        }
//    }
//    else if (command == "max")
//    {
//        string oddEven = input[1];

//        GetMax(numbers, oddEven);

//    }
//    else if (command == "min")
//    {
//        string oddEven = input[1];

//        GetMin(numbers, oddEven);
//    }
//    else if (command == "first")
//    {
//        int count = int.Parse(input[1]);
//        string oddEven = input[2];

//        if (count > numbers.Length)
//        {
//            Console.WriteLine("Invalid count");
//            continue;
//        }

//        elements = GetFirstElements(numbers, count, oddEven);

//        PrintArray(elements);
//    }
//    else if (command == "last")
//    {
//        int count = int.Parse(input[1]);
//        string oddEven = input[2];

//        if (count > numbers.Length)
//        {
//            Console.WriteLine("Invalid count");
//            continue;
//        }

//        elements = GetLastElements(numbers, count, oddEven);

//        PrintArray(elements);
//    }
//}

//Console.WriteLine($"[{string.Join(", ", numbers)}]");

//static void PrintArray(int[] array)
//{
//    Console.Write("[");

//    for (int i = 0; i < array.Length; i++)
//    {
//        if (i == array.Length - 1)
//        {
//            Console.Write($"{array[i]}");
//        }
//        else
//        {
//            Console.Write($"{array[i]}, ");
//        }
//    }
//    Console.WriteLine("]");
//}

////static void PrintArray(int[] array)
////{
////    Console.Write("[");
////    bool isSecond = false;

////    foreach (int element in array)
////    {
////        if (isSecond)
////        {
////            Console.Write($", {element}");
////        }
////        else
////        {
////            Console.Write($"{element}");
////            isSecond = true;
////        }
////    }
////    Console.WriteLine("]");
////}

////static void PrintArray(int[] array)
////{
////    Console.Write("[");

////    for (int i = 0; i < array.Length; i++)
////    {
////        Console.Write(array[i]);

////        if (i < array.Length - 1)
////        {
////            Console.Write(", ");
////        }
////    }

////    Console.WriteLine("]");
////}

//static int[] GetLastElements(int[] array, int count, string oddEven)
//{
//    int[] lastElements = new int[count];
//    int param = GetParam(oddEven);
//    int index = 0;

//    for (int i = array.Length - 1; i >= 0; i--)
//    {
//        if (array[i] % 2 == param && index < count)
//        {
//            lastElements[index] = array[i];
//            index++;
//        }
//    }
//    int[] lastElementsCount = new int[index];

//    for (int i = 0; i < index; i++)
//    {
//        lastElementsCount[i] = lastElements[index - 1 - i];
//    }

//    return lastElementsCount;
//}

//static int[] GetFirstElements(int[] array, int count, string oddEven)
//{
//    int[] firstElements = new int[count];
//    int param = GetParam(oddEven);
//    int index = 0;

//    foreach (var element in array)
//    {
//        if (element % 2 == param && index < count)
//        {
//            firstElements[index] = element;
//            index++;
//        }
//    }

//    int[] firstElementsCount = new int[index];

//    for (int i = 0; i < firstElementsCount.Length; i++)
//    {
//        firstElementsCount[i] = firstElements[i];
//    }

//    return firstElementsCount;
//}

//static void GetMin(int[] array, string oddEven)
//{
//    int param = GetParam(oddEven);

//    int minNumber = int.MaxValue;
//    int minIndex = -1;
//    int index = 0;

//    foreach (int i in array)
//    {
//        if (i % 2 == param && i <= minNumber)
//        {
//            minNumber = i;
//            minIndex = index;
//        }

//        index++;
//    }

//    if (minIndex == -1)
//    {
//        Console.WriteLine("No matches");
//    }
//    else
//    {
//        Console.WriteLine(minIndex);
//    }
//}

//static void GetMax(int[] array, string oddEven)
//{
//    int param = GetParam(oddEven);

//    int maxNumber = int.MinValue;
//    int maxIndex = -1;
//    int index = 0;

//    foreach (int i in array)
//    {
//        if (i % 2 == param && i >= maxNumber)
//        {
//            maxNumber = i;
//            maxIndex = index;
//        }

//        index++;
//    }

//    if (maxIndex != -1)
//    {
//        Console.WriteLine(maxIndex);
//    }
//    else
//    {
//        Console.WriteLine("No matches");
//    }
//}

//static int GetParam(string oddEven)
//{
//    if (oddEven == "even")
//    {
//        return 0;
//    }
//    else
//    {
//        return 1;
//    }
//}

//static void ArrayIndexExchange(int[] array, int index)
//{
//    for (int i = 0; i <= index; i++)
//    {
//        int temp = array[0];

//        for (int j = 1; j < array.Length; j++)
//        {
//            array[j - 1] = array[j];
//        }

//        array[array.Length - 1] = temp;
//    }
//}

////3
//int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

//string[] input;

//while ((input = Console.ReadLine().Split())[0] != "end")
//{
//    string command = input[0];
//    int length = int.Parse(input[1]);
//    string parameter = input[2];

//    if (length > array.Length)
//    {
//        Console.WriteLine("Invalid count");
//    }
//    else
//    {
//        int[] elements = GetFirstElements(array, length, parameter);

//        PrintElements(elements);
//    }

//}

//static void PrintElements(int[] elements)
//{
//    bool isSecond = false;

//    Console.Write("[");

//    for (int i = 0; i < elements.Length; i++)
//    {
//        if (isSecond)
//        {
//            Console.Write($", {elements[i]}");
//        }
//        else
//        {
//            Console.Write($"{elements[i]}");
//            isSecond = true;
//        }
//    }
//    Console.WriteLine("]");
//}

//static int[] GetFirstElements(int[] array, int length, string parameter)
//{
//    int evenOrOdd = 0;

//    if (parameter == "even")
//    {
//        evenOrOdd = 0;
//    }
//    else
//    {
//        evenOrOdd = 1;
//    }

//    int counter = 0;

//    foreach (int element in array)
//    {
//        if (element % 2 == evenOrOdd)
//        {
//            counter++;
//        }
//    }

//    int[] firstElements;

//    if (counter > length)
//    {
//        firstElements = new int[length];
//    }
//    else
//    {
//        firstElements = new int[counter];
//    }


//    int index = 0;

//    if (firstElements.Length == 0)
//    {
//        return firstElements;
//    }

//    foreach (int element in array)
//    {
//        if (element % 2 == 0 && parameter == "even")
//        {
//            firstElements[index] = element;
//            index++;
//        }
//        else if (element % 2 == 1 && parameter == "odd")
//        {
//            firstElements[index] = element;
//            index++;
//        }

//        if (index == firstElements.Length)
//        {
//            break;
//        }

//    }

//    return firstElements;
//}