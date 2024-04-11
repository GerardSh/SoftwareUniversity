int fieldSize = int.Parse(Console.ReadLine());

char[,] field = new char[fieldSize, fieldSize];

string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

int startingPositionRow = 0;
int startingPositionCol = 0;
int remainingCoals = 0;

for (int row = 0; row < fieldSize; row++)
{
    char[] array = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < fieldSize; col++)
    {
        field[row, col] = array[col];

        if (field[row, col] == 's')
        {
            startingPositionRow = row;
            startingPositionCol = col;
        }

        if (field[row, col] == 'c')
        {
            remainingCoals++;
        }
    }
}

int currentRow = startingPositionRow;
int currentCol = startingPositionCol;

for (int i = 0; i < directions.Length; i++)
{
    string direction = directions[i];

    if (!ValidMove(field, direction, currentRow, currentCol))
    {
        continue;
    }

    if (direction == "up")
    {
        currentRow--;
    }
    else if (direction == "down")
    {
        currentRow++;
    }
    else if (direction == "left")
    {
        currentCol--;
    }
    else if (direction == "right")
    {
        currentCol++;
    }

    if (field[currentRow, currentCol] == 'c')
    {
        remainingCoals--;
        field[currentRow, currentCol] = '*';

        if (remainingCoals == 0)
        {
            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
            return;
        }
    }
    else if (field[currentRow, currentCol] == 'e')
    {
        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
        return;
    }
}

Console.WriteLine($"{remainingCoals} coals left. ({currentRow}, {currentCol})");

static bool ValidMove(char[,] field, string direction, int currentRow, int currentCol)
{
    if (direction == "up")
    {
        return currentRow - 1 >= 0;
    }
    else if (direction == "down")
    {
        return currentRow + 1 < field.GetLength(0);
    }
    else if (direction == "left")
    {
        return currentCol - 1 >= 0;
    }
    else if (direction == "right")
    {
        return currentCol + 1 < field.GetLength(1);
    }

    return false;
}