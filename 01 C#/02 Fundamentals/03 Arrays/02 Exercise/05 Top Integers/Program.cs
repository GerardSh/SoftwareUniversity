int[] numbersArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

for (int i = 0; i < numbersArr.Length; i++)
{
    bool isBigger = true;

    for (int j = i + 1; j < numbersArr.Length; j++)
    {
        if (numbersArr[i] <= numbersArr[j])
        {
            isBigger = false;
        }
    }

    if (isBigger)
    {
        Console.Write(numbersArr[i] + " ");
    }
}