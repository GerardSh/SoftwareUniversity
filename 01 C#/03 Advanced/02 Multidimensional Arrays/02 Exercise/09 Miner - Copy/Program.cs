using System.ComponentModel;

string[] matrixDimensions = Console.ReadLine().Split();

char[,] matrix = new char[int.Parse(matrixDimensions[0]), int.Parse(matrixDimensions[1])];

int playerRow = 0;
int playerCol = 0;
int bunniesCount = 0;

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

        if (input[col] == 'B')
        {
            bunniesCount++;
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
        playerRow--;
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

    if (matrix[playerRow, playerCol] == 'B')
    {
        hasDied = true;
    }

    //    if (hasWon || hasDied)
    //    {
    //        break;
    //    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col] + " ");
    }

    Console.WriteLine();
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
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                        {
                            newMatrix[i, j] = 'B';
                        }
                    }
                }
                //Second option
                //if (row - 1 >= 0)
                //{
                //    matrix[row - 1, col] = 'B';
                //}

                //if (row + 1 < matrix.GetLength(0))
                //{
                //    matrix[row + 1, col] = 'B';
                //}

                //if (col - 1 >= 0)
                //{
                //    matrix[row, col - 1] = 'B';
                //}

                //if (col + 1 < matrix.GetLength(1))
                //{
                //    matrix[row, col + 1] = 'B';
                //}
            }
        }
    }
;
    return newMatrix;
}