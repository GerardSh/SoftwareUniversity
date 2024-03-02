int[] fieldArr = new int[int.Parse(Console.ReadLine())];
long[] initialIndexes = Console.ReadLine().Split().Select(long.Parse).ToArray();

for (int i = 0; i < fieldArr.Length; i++)
{
    for (int j = 0; j < initialIndexes.Length; j++)
    {
        if (initialIndexes[j] == i)
        {
            fieldArr[i] = 1;
        }
    }
}

string[] inputArr;

while ((inputArr = Console.ReadLine().Split())[0] != "end")
{
    long indexBug = long.Parse(inputArr[0]);
    string command = inputArr[1];
    long movePosition = long.Parse(inputArr[2]);

    if (command == "left")
    {
        movePosition *= -1;
    }

    if (indexBug >= 0 && indexBug < fieldArr.Length
        && fieldArr[indexBug] == 1
        && movePosition != 0)
    {
        bool hasLandedOrFleet = false;

        while (!hasLandedOrFleet)
        {
            if (indexBug + movePosition > fieldArr.Length - 1 || indexBug + movePosition < 0)
            {
                fieldArr[indexBug] = 0;
                break;
            }

            if (fieldArr[indexBug + movePosition] == 0)
            {
                hasLandedOrFleet = true;
                fieldArr[indexBug] = 0;
                fieldArr[indexBug + movePosition] = 1;
            }
            else
            {
                movePosition *= 2;
            }
        }
    }
    else
    {
        continue;
    }
}

Console.WriteLine(string.Join(" ", fieldArr));

////2
//int fieldSize = int.Parse(Console.ReadLine());
//int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

//bool[] field = new bool[fieldSize];

//foreach (int index in indexes)
//{
//    if (index >= 0 && index < field.Length)
//    {
//        field[index] = true;
//    }
//}

//string input;

//while ((input = Console.ReadLine()) != "end")
//{
//    string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

//    int index = int.Parse(inputArr[0]);
//    string command = inputArr[1];
//    int movingLength = int.Parse(inputArr[2]);

//    if (index >= 0 && index < field.Length && field[index])
//    {
//        bool hasFledOrLanded = false;
//        field[index] = false;

//        while (!hasFledOrLanded)
//        {
//            if (command == "right")
//            {
//                index += movingLength;
//            }
//            else
//            {
//                index -= movingLength;
//            }

//            if (index < 0 || index >= field.Length)
//            {
//                hasFledOrLanded = true;
//            }
//            else if (field[index])
//            {
//                continue;
//            }
//            else
//            {
//                field[index] = true;
//                hasFledOrLanded = true;
//            }
//        }
//    }
//}

//foreach (var element in field)
//{
//    if (element)
//    {
//        Console.Write("1 ");
//    }
//    else
//    {
//        Console.Write("0 ");
//    }
//}