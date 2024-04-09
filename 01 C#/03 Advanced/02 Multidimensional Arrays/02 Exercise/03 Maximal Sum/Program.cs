int[] matrixDimensions = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[matrixDimensions[0], matrixDimensions[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] elements = Console.ReadLine()
        .Split();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

int[] subMatrix = { 3, 3 };

int maxSum = int.MinValue;
int bestRow = 0;
int bestCol = 0;

for (int row = 0; row <= matrix.GetLength(0) - subMatrix[0]; row++)
{
    for (int col = 0; col <= matrix.GetLength(1) - subMatrix[1]; col++)
    {
        int subMatrixSum = 0;

        for (int subRow = 0; subRow < subMatrix[0]; subRow++)
        {
            for (int subCol = 0; subCol < subMatrix[1]; subCol++)
            {
                subMatrixSum += matrix[row + subRow, col + subCol];
            }
        }

        if (subMatrixSum > maxSum)
        {
            maxSum = subMatrixSum;
            bestRow = row;
            bestCol = col;
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");

for (int row = bestRow; row < bestRow + subMatrix[0]; row++)
{
    for (int col = bestCol; col < bestCol + subMatrix[1]; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }

    Console.WriteLine();
}