PrintTitle();
Console.WriteLine("Escape from the island of the zombie bunnies! Each move you make spawns more in all directions! Many have failed to survive...");
Console.WriteLine();
Console.WriteLine("Press any key to continue if you dare!");
Console.ReadLine();
Console.Beep();
PrintTitle();

char[,] matrix = null;

Console.WriteLine("Choose field size - press 's' + Enter for small, 'm' + Enter for medium, 'l' + Enter for large and 'r' + Enter for large field with random spawn location");
string fieldSize = Console.ReadLine();
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
    field = ".......B..............................B.....................................................................................................................................................................................................................................................................................................................................................................................................................................................................B.....................................................B.....................B...............................................................B.....";
    field = field.Insert(random.Next(0, field.Count() - 1), "P");
    matrix = new char[15, 50];
}

Console.Beep();

int index = 0;

int playerRow = 0;
int playerCol = 0;

PrintTitle();
Console.WriteLine("Choose your character outlook and press Enter, it should be one symbol!");

char character = char.Parse(Console.ReadLine());

Console.Beep();

PrintTitle();
Console.WriteLine("To move up - press 'w' + Enter");
Console.WriteLine("To move down - press 's' + Enter");
Console.WriteLine("To move right - press 'd' + Enter");
Console.WriteLine("To move left - press 'a' + Enter");
Console.WriteLine();
Console.WriteLine("Press any key to start the game!");
Console.ReadLine();
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
    char direction = char.Parse(Console.ReadLine());

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