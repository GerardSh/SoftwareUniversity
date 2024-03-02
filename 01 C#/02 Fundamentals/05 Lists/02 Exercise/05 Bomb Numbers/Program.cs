List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int specialNumber = array[0];
int power = array[1];

for (int i = 0; i < numbers.Count; i++)
{
    if (numbers[i] == specialNumber)
    {
        int removeIndexLeft;
        int countRight = power;


        if (i - power < 0)
        {
            removeIndexLeft = 0;
        }
        else
        {
            removeIndexLeft = i - power;
        }
        if (i + power > numbers.Count - 1)
        {
            countRight = numbers.Count - 1 - i;
        }

        if (power + 1 + countRight > numbers.Count - 1)
        {
            numbers.RemoveRange(0, numbers.Count);
            break;
        }
        else
        {
            numbers.RemoveRange(removeIndexLeft, power + 1 + countRight);
        }

        i = -1;
    }
}

Console.WriteLine(string.Join(" ", numbers.Sum()));

////2
//List<int> numbers = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToList();

//int[] array = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToArray();

//int specialNumber = array[0];
//int power = array[1];

//while (numbers.IndexOf(specialNumber) != -1)
//{
//    int bombIndex = numbers.IndexOf(specialNumber);
//    int startIndex;
//    int count = power * 2 + 1;

//    if (bombIndex - power < 0)
//    {
//        startIndex = 0;
//        count = power + 1 + bombIndex;
//    }
//    else
//    {
//        startIndex = bombIndex - power;
//    }



//    //var1

//    if (startIndex + count > numbers.Count - 1)
//    {
//        count = numbers.Count - startIndex;
//    }

//    numbers.RemoveRange(startIndex, count);

//    ////var2

//    //if (startIndex + count > numbers.Count - 1)
//    //{
//    //    for (int i = startIndex; i < numbers.Count; i++)
//    //    {
//    //        numbers.RemoveAt(i--);
//    //    }
//    //}
//    //else
//    //{
//    //    numbers.RemoveRange(startIndex, count);
//    //}
//}

//Console.WriteLine(numbers.Sum());
