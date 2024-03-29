string[] elements = Console.ReadLine().Split(", ");

int rows = int.Parse(elements[0]);
int cols = int.Parse(elements[1]);

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    elements = Console.ReadLine().Split(", ");

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

int biggestSum = 0;
string subMatrix = "";

for (int row = 0; row < rows - 1; row++)
{
    for (int col = 0; col < cols - 1; col++)
    {
        int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, +col] + matrix[row + 1, col + 1];

        if (biggestSum < currentSum)
        {
            biggestSum = currentSum;
            subMatrix = $"{matrix[row, col]} {matrix[row, col + 1]}\n{matrix[row + 1, col]} {matrix[row + 1, col + 1]}";
        }
    }
}

Console.WriteLine(subMatrix);
Console.WriteLine(biggestSum);




//Performing the same exercise but with the addition of defining the sub-matrix size.
string[] elements = Console.ReadLine().Split(", ");

int rows = int.Parse(elements[0]);
int cols = int.Parse(elements[1]);

elements = Console.ReadLine().Split(", ");

int subMatrixRows = int.Parse(elements[0]);
int subMatrixCols = int.Parse(elements[1]);

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    elements = Console.ReadLine().Split(", ");

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

int biggestSum = 0;
int biggestRow = 0;
int biggestCol = 0;

for (int row = 0; row < rows - subMatrixRows + 1; row++)
{
    for (int col = 0; col < cols - subMatrixCols + 1; col++)
    {
        int subMatrixSum = 0;

        for (int subRow = 0; subRow < subMatrixRows; subRow++)
        {
            for (int subCol = 0; subCol < subMatrixCols; subCol++)
            {
                subMatrixSum += matrix[row + subRow, col + subCol];
            }
        }

        if (biggestSum < subMatrixSum)
        {
            biggestSum = subMatrixSum;
            biggestRow = row;
            biggestCol = col;
        }
    }
}

for (int row = biggestRow; row < biggestRow + subMatrixRows; row++)
{
    for (int col = biggestCol; col < biggestCol + subMatrixCols; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }

    Console.WriteLine();
}

Console.WriteLine(biggestSum);