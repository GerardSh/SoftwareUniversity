int[] matrixDimensions = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];


for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] elements = Console.ReadLine()
        .Split();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = char.Parse(elements[col]);
    }
}

int[] subMatrix = { 2, 2 };

int squaresCount = 0;

for (int row = 0; row <= matrix.GetLength(0) - subMatrix[0]; row++)
{
    for (int col = 0; col <= matrix.GetLength(1) - subMatrix[1]; col++)
    {
        int equalChars = 0;
        bool isEqual = true;

        for (int subRow = 0; subRow < subMatrix[0]; subRow++)
        {
            for (int subCol = 0; subCol < subMatrix[1]; subCol++)
            {
                if (matrix[row + subRow, col + subCol] != matrix[row, col])
                {
                    isEqual = false;
                    break;
                }

                equalChars++;
            }

            if (!isEqual)
            {
                break;
            }
        }

        if (equalChars == subMatrix[0] * subMatrix[1])
        {
            squaresCount++;
        }
    }
}

Console.WriteLine(squaresCount);