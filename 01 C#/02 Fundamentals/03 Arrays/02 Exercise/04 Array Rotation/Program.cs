int[] numbersArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] rotatedArr = new int[numbersArr.Length];
int rotations = int.Parse(Console.ReadLine());
int rotationIndex = 0;

if (rotations == 0)
{
    rotatedArr = numbersArr;
}
else
{
    for (int i = 0; i < rotations; i++)
    {
        for (int j = 0; j < numbersArr.Length; j++)
        {
            if (j < numbersArr.Length - 1)
            {
                rotatedArr[j] = numbersArr[j + 1];
            }
            else
            {
                rotatedArr[j] = numbersArr[0];
            }
        }
        Array.Copy(rotatedArr, numbersArr, numbersArr.Length);
    }
}

Console.WriteLine(string.Join(" ", rotatedArr));

////2 
//int[] numbersArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//int rotations = int.Parse(Console.ReadLine());

//for (int i = 0; i < rotations; i++)
//{
//    int firstNumber = numbersArr[0];

//    for (int j = 0; j < numbersArr.Length - 1; j++)
//    {
//        int nextIndex = j + 1;

//        numbersArr[j] = numbersArr[nextIndex];
//    }

//    numbersArr[numbersArr.Length - 1] = firstNumber;
//}

//Console.WriteLine(string.Join(" ", numbersArr));