int[] matrixDimensions = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

string snake = Console.ReadLine();

char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];
int snakeIndex = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = snake[snakeIndex++];

            if (snakeIndex == snake.Length)
            {
                snakeIndex = 0;
            }
        }
    }
    else
    {
        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
        {
            matrix[row, col] = snake[snakeIndex++];

            if (snakeIndex == snake.Length)
            {
                snakeIndex = 0;
            }
        }
    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);
    }

    Console.WriteLine();
}