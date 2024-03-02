int[] k = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int numbersPart = k.Length / 4;

int[] firstPart = new int[numbersPart];
int[] lastPart = new int[numbersPart];
int[] middlePart = new int[numbersPart * 2];

int countFirst = 0;

for (int i = numbersPart - 1; i >= 0; i--)
{
    firstPart[countFirst] = k[i];
    countFirst++;
}

int countSecond = 0;

for (int i = k.Length - 1; i > k.Length - 1 - numbersPart; i--)
{
    lastPart[countSecond] = k[i];
    countSecond++;
}

int countMiddle = 0;

for (int i = 0; i < k.Length; i++)
{
    if (i > numbersPart - 1 && i < k.Length - numbersPart)
    {
        middlePart[countMiddle] = k[i];
        countMiddle++;
    }
}

int[] combinedArr = new int[numbersPart * 2];

int countMerge = 0;

for (int i = 0; i < combinedArr.Length; i++)
{
    if (i < numbersPart)
    {
        combinedArr[i] = firstPart[i];
    }
    else
    {
        combinedArr[i] = lastPart[countMerge];
        countMerge++;
    }
}

int[] foldedArr = new int[combinedArr.Length];

for (int i = 0; i < combinedArr.Length; i++)
{
    foldedArr[i] = combinedArr[i] + middlePart[i];
}

Console.WriteLine(string.Join(" ", foldedArr));



//for (int i = 0; i < k.Length; i++)
//{
//    if (i < numbersInHalf)
//    {
//        firstPart[i] = k[i];
//    }
//    else if (i > k.Length - 1 - numbersInHalf)
//    {
//        lastPart[i-numbersInHalf*3] = k[i];
//    }
//    else
//    {
//        middlePart[i - numbersInHalf] = k[i];
//    }
//}