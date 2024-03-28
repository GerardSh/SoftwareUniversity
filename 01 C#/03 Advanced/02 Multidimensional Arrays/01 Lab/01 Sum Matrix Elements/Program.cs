string[] elements = Console.ReadLine().Split(", ");

int rows = int.Parse(elements[0]);
int columns = int.Parse(elements[1]);

int[,] matrix = new int[rows, columns];

for (int row = 0; row < rows; row++)
{
    elements = Console.ReadLine().Split(", ");

    for (int col = 0; col < columns; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

int sumElements = 0;

foreach (int element in matrix)
{
    sumElements += element;
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sumElements);