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




//2
int[] numbers = console.readline().split().select(int.parse).toarray();

string[] input;
int[] elements;

while ((input = console.readline().split())[0] != "end")
{
    string command = input[0];

    if (command == "exchange")
    {
        int index = int.parse(input[1]);

        if (index < 0 || index >= numbers.length)
        {
            console.writeline("invalid index");
        }
        else
        {
            arrayindexexchange(numbers, index);
        }
    }
    else if (command == "max")
    {
        string oddeven = input[1];

        getmax(numbers, oddeven);

    }
    else if (command == "min")
    {
        string oddeven = input[1];

        getmin(numbers, oddeven);
    }
    else if (command == "first")
    {
        int count = int.parse(input[1]);
        string oddeven = input[2];

        if (count > numbers.length)
        {
            console.writeline("invalid count");
            continue;
        }

        elements = getfirstelements(numbers, count, oddeven);

        printarray(elements);
    }
    else if (command == "last")
    {
        int count = int.parse(input[1]);
        string oddeven = input[2];

        if (count > numbers.length)
        {
            console.writeline("invalid count");
            continue;
        }

        elements = getlastelements(numbers, count, oddeven);

        printarray(elements);
    }
}

console.writeline($"[{string.join(", ", numbers)}]");

static void printarray(int[] array)
{
    console.write("[");

    for (int i = 0; i < array.length; i++)
    {
        if (i == array.length - 1)
        {
            console.write($"{array[i]}");
        }
        else
        {
            console.write($"{array[i]}, ");
        }
    }
    console.writeline("]");
}

//static void printarray(int[] array)
//{
//    console.write("[");
//    bool issecond = false;

//    foreach (int element in array)
//    {
//        if (issecond)
//        {
//            console.write($", {element}");
//        }
//        else
//        {
//            console.write($"{element}");
//            issecond = true;
//        }
//    }
//    console.writeline("]");
//}

//static void printarray(int[] array)
//{
//    console.write("[");

//    for (int i = 0; i < array.length; i++)
//    {
//        console.write(array[i]);

//        if (i < array.length - 1)
//        {
//            console.write(", ");
//        }
//    }

//    console.writeline("]");
//}

static int[] getlastelements(int[] array, int count, string oddeven)
{
    int[] lastelements = new int[count];
    int param = getparam(oddeven);
    int index = 0;

    for (int i = array.length - 1; i >= 0; i--)
    {
        if (array[i] % 2 == param && index < count)
        {
            lastelements[index] = array[i];
            index++;
        }
    }
    int[] lastelementscount = new int[index];

    for (int i = 0; i < index; i++)
    {
        lastelementscount[i] = lastelements[index - 1 - i];
    }

    return lastelementscount;
}

static int[] getfirstelements(int[] array, int count, string oddeven)
{
    int[] firstelements = new int[count];
    int param = getparam(oddeven);
    int index = 0;

    foreach (var element in array)
    {
        if (element % 2 == param && index < count)
        {
            firstelements[index] = element;
            index++;
        }
    }

    int[] firstelementscount = new int[index];

    for (int i = 0; i < firstelementscount.length; i++)
    {
        firstelementscount[i] = firstelements[i];
    }

    return firstelementscount;
}

static void getmin(int[] array, string oddeven)
{
    int param = getparam(oddeven);

    int minnumber = int.maxvalue;
    int minindex = -1;
    int index = 0;

    foreach (int i in array)
    {
        if (i % 2 == param && i <= minnumber)
        {
            minnumber = i;
            minindex = index;
        }

        index++;
    }

    if (minindex == -1)
    {
        console.writeline("no matches");
    }
    else
    {
        console.writeline(minindex);
    }
}

static void getmax(int[] array, string oddeven)
{
    int param = getparam(oddeven);

    int maxnumber = int.minvalue;
    int maxindex = -1;
    int index = 0;

    foreach (int i in array)
    {
        if (i % 2 == param && i >= maxnumber)
        {
            maxnumber = i;
            maxindex = index;
        }

        index++;
    }

    if (maxindex != -1)
    {
        console.writeline(maxindex);
    }
    else
    {
        console.writeline("no matches");
    }
}

static int getparam(string oddeven)
{
    if (oddeven == "even")
    {
        return 0;
    }
    else
    {
        return 1;
    }
}

static void arrayindexexchange(int[] array, int index)
{
    for (int i = 0; i <= index; i++)
    {
        int temp = array[0];

        for (int j = 1; j < array.length; j++)
        {
            array[j - 1] = array[j];
        }

        array[array.length - 1] = temp;
    }
}




//3
int[] array = console.readline().split(" ", stringsplitoptions.removeemptyentries).select(int.parse).toarray();

string[] input;

while ((input = console.readline().split())[0] != "end")
{
    string command = input[0];
    int length = int.parse(input[1]);
    string parameter = input[2];

    if (length > array.length)
    {
        console.writeline("invalid count");
    }
    else
    {
        int[] elements = getfirstelements(array, length, parameter);

        printelements(elements);
    }

}

static void printelements(int[] elements)
{
    bool issecond = false;

    console.write("[");

    for (int i = 0; i < elements.length; i++)
    {
        if (issecond)
        {
            console.write($", {elements[i]}");
        }
        else
        {
            console.write($"{elements[i]}");
            issecond = true;
        }
    }
    console.writeline("]");
}

static int[] getfirstelements(int[] array, int length, string parameter)
{
    int evenorodd = 0;

    if (parameter == "even")
    {
        evenorodd = 0;
    }
    else
    {
        evenorodd = 1;
    }

    int counter = 0;

    foreach (int element in array)
    {
        if (element % 2 == evenorodd)
        {
            counter++;
        }
    }

    int[] firstelements;

    if (counter > length)
    {
        firstelements = new int[length];
    }
    else
    {
        firstelements = new int[counter];
    }


    int index = 0;

    if (firstelements.length == 0)
    {
        return firstelements;
    }

    foreach (int element in array)
    {
        if (element % 2 == 0 && parameter == "even")
        {
            firstelements[index] = element;
            index++;
        }
        else if (element % 2 == 1 && parameter == "odd")
        {
            firstelements[index] = element;
            index++;
        }

        if (index == firstelements.length)
        {
            break;
        }

    }

    return firstelements;
}