﻿PrintTitle();
Console.WriteLine("Escape from the island of the zombie bunnies! Each move you make spawns more in all directions! Many have failed to survive...");
Console.WriteLine();
Console.WriteLine("Press any key to continue if you dare!");
Console.ReadKey();
Console.Beep();
PrintTitle();

char[,] matrix = null;

Console.WriteLine("Choose field size - press 's' for small, 'm' for medium, 'l' for large and 'r' for large field with random spawn locations");

string fieldSize = Console.ReadKey().KeyChar.ToString();

while (fieldSize != "s" && fieldSize != "m" && fieldSize != "l" && fieldSize != "r")
{
    Console.Beep();
    Console.Clear();
    PrintTitle();
    Console.WriteLine("Wrong field size, choose again!");
    Console.WriteLine("Press 's' for small, 'm' for medium, 'l' for large and 'r' for large field with random spawn locations");
    fieldSize = Console.ReadKey().KeyChar.ToString();
}

string field = null;

if (fieldSize == "s")
{
    field = ".......B........................B......P.......B................................";
    matrix = new char[5, 16];
}
else if (fieldSize == "m")
{
    field = ".......B......................................................B..............B.......................................................................P......................B......................................................B.....................B......................................................................";
    matrix = new char[10, 32];
}
else if (fieldSize == "l")
{
    field = ".......B..............................B.....................................................................................................................................................................................................................................................................................................................................................................................................................................................................B.......................P..............................B.....................B...............................................................B.....";
    matrix = new char[15, 50];
}
else if (fieldSize == "r")
{
    Random random = new Random();
    field = "..............................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................";
    int playerPosition = random.Next(0, field.Count() - 100);
    field = field.Insert(playerPosition, "P");
    matrix = new char[15, 50];

    for (int i = 0; i < 10; i++)
    {
        int randomPosition = 0;

        do
        {
            randomPosition = random.Next(0, field.Count() - 1);
        }
        while (field[randomPosition] != '.');

        field = field.Insert(randomPosition, "B");
    }
}

Console.Beep();

int index = 0;

int playerRow = 0;
int playerCol = 0;

PrintTitle();
Console.WriteLine("Choose your character outlook, it should be one symbol!");

char character = Console.ReadKey().KeyChar;

Console.Beep();

PrintTitle();
Console.WriteLine("To move up - press 'w'");
Console.WriteLine("To move down - press 's'");
Console.WriteLine("To move right - press 'd'");
Console.WriteLine("To move left - press 'a'");
Console.WriteLine();
Console.WriteLine("Press any key to start the game!");
Console.ReadKey();
Console.Beep();
Console.Clear();

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = field[index];

        if (field[index] == 'P')
        {
            playerRow = row;
            playerCol = col;
            matrix[row, col] = character;
        }

        if (index < field.Count() - 1)
        {
            index++;
        }
    }
}

void PrintTitle()
{
    Console.Clear();
    Console.WriteLine(
$@"*************************
*Welcome to BunnyGeddon!*
*************************");
    Console.WriteLine();
}

PrintMatrix(matrix);

bool hasWon = false;
bool hasDied = false;

while (true)
{
    char direction = Console.ReadKey().KeyChar;

    if (direction != 'w' && direction != 's' && direction != 'a' && direction != 'd')
    {
        Console.Beep();
        Console.Clear();
        PrintMatrix(matrix);
        Console.WriteLine("Wrong move, try again!");
        continue;
    }

    if (direction == 'w' && playerRow > 0)
    {
        matrix[playerRow, playerCol] = '.';
        playerRow--;
        matrix[playerRow, playerCol] = character;
    }
    else if (direction == 's' && playerRow + 1 < matrix.GetLength(0))
    {
        matrix[playerRow, playerCol] = '.';
        playerRow++;
        matrix[playerRow, playerCol] = character;
    }
    else if (direction == 'a' && playerCol > 0)
    {
        matrix[playerRow, playerCol] = '.';
        playerCol--;
        matrix[playerRow, playerCol] = character;
    }
    else if (direction == 'd' && playerCol + 1 < matrix.GetLength(1))
    {
        matrix[playerRow, playerCol] = '.';
        playerCol++;
        matrix[playerRow, playerCol] = character;
    }
    else
    {
        matrix[playerRow, playerCol] = '.';
        hasWon = true;
    }

    matrix = BunniesSpread(matrix);

    Console.Beep();
    Console.Clear();

    PrintMatrix(matrix);

    if (matrix[playerRow, playerCol] == 'B' && !hasWon)
    {
        matrix[playerRow, playerCol] = 'B';
        hasDied = true;
    }

    if (hasWon || hasDied)
    {
        break;
    }
}

if (fieldSize != "s" || fieldSize == "s" && !hasWon)
{
    Console.Clear();
}

PrintMatrix(matrix);

if (hasWon)
{
    Console.WriteLine($"You WON!");
}
else
{
    Console.WriteLine($"You are DEAD!");
}

if (fieldSize != "s")
{
    Console.WriteLine();
    Console.WriteLine("Bonus tip: Beat the game on a small field with three down moves!");
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