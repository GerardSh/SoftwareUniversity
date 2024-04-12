string[] matrixDimensions = Console.ReadLine().Split();

char[,] matrix = new char[int.Parse(matrixDimensions[0]), int.Parse(matrixDimensions[1])];

int playerRow = 0;
int playerCol = 0;

for (int row = 0; row < int.Parse(matrixDimensions[0]); row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];

        if (input[col] == 'P')
        {
            playerRow = row;
            playerCol = col;
            matrix[row, col] = '.';
        }
    }
}

var directions = Console.ReadLine();
bool hasWon = false;
bool hasDied = false;

foreach (var direction in directions)
{
    if (direction == 'U' && playerRow > 0)
    {
        playerRow--;
    }
    else if (direction == 'D' && playerRow + 1 < matrix.GetLength(0))
    {
        playerRow++;
    }
    else if (direction == 'L' && playerCol > 0)
    {
        playerCol--;
    }
    else if (direction == 'R' && playerCol + 1 < matrix.GetLength(1))
    {
        playerCol++;
    }
    else
    {
        hasWon = true;
    }

    matrix = BunniesSpread(matrix);

    if (matrix[playerRow, playerCol] == 'B' && !hasWon)
    {
        hasDied = true;
    }

    if (hasWon || hasDied)
    {
        break;
    }
}

PrintMatrix(matrix);

if (hasWon)
{
    Console.WriteLine($"won: {playerRow} {playerCol}");
}
else
{
    Console.WriteLine($"dead: {playerRow} {playerCol}");
}
void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }

        Console.WriteLine();
    }
}

static char[,] BunniesSpread(char[,] matrix)
{
    char[,] newMatrix = (char[,])matrix.Clone();

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'B')
            {
                if (row - 1 >= 0)
                {
                    newMatrix[row - 1, col] = 'B';
                }

                if (row + 1 < matrix.GetLength(0))
                {
                    newMatrix[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    newMatrix[row, col - 1] = 'B';
                }

                if (col + 1 < matrix.GetLength(1))
                {
                    newMatrix[row, col + 1] = 'B';
                }
            }
        }
    }

    return newMatrix;
}