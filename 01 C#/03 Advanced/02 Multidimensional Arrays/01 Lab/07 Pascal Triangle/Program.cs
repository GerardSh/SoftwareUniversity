int n = int.Parse(Console.ReadLine());

ulong[][] jaggedArray = new ulong[n][];

for (int row = 0; row < jaggedArray.Length; row++)
{
    jaggedArray[row] = new ulong[row + 1];

    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        if (col == 0 || col == jaggedArray[row].Length - 1)
        {
            jaggedArray[row][col] = 1;
        }
        else
        {
            jaggedArray[row][col] = jaggedArray[row - 1][col] + jaggedArray[row - 1][col - 1];
        }
    }
}

for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write(jaggedArray[row][col] + " ");
    }

    Console.WriteLine();
}