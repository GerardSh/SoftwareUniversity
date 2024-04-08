int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];
int count = 0;
int primaryDiagonal = 0;
int secondaryDiagonal = 0;

for (int row = 0; row < n; row++)
{
    int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

    primaryDiagonal += array[count];
    secondaryDiagonal += array[array.Length - 1 - count];

    //int[] arrayReversed = array;
    //Array.Reverse(arrayReversed);
    //secondaryDiagonal += arrayReversed[count];

    count++;

    for (int col = 0; col < n; col++)
    {
        matrix[row, col] = array[col];
    }
}

Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));