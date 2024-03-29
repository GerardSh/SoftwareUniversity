string[] elements = Console.ReadLine().Split(", ");

int rows = int.Parse(elements[0]);
int cols = int.Parse(elements[1]);

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    elements = Console.ReadLine().Split();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

//variant 1
for (int col = 0; col < cols; col++)
{
    int sum = 0;

    for (int row = 0; row < rows; row++)
    {
        sum += matrix[row, col];
    }

    Console.WriteLine(sum);
}

//variant 2
int[] sumCols = new int[matrix.GetLength(1)];

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        sumCols[col] += matrix[row, col];
    }
}

foreach (int col in sumCols)
{
    Console.WriteLine(col);
}