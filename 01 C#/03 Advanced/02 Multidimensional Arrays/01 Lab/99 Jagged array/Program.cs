int n = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[n][];

for (int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split();

    jaggedArray[i] = new int[elements.Length];

    for (int j = 0; j < elements.Length; j++)
    {
        jaggedArray[i][j] = int.Parse(elements[j]);
    }
}

for (int i = 0; i < jaggedArray.Length; ++i)
{
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        Console.Write(jaggedArray[i][j] + " ");
    }

    Console.WriteLine();
}