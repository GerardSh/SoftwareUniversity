int[] matrixDimensions = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

string[,] matrix = new string[matrixDimensions[0], matrixDimensions[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] elements = Console.ReadLine()
        .Split();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = elements[col];
    }
}

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (!ValidCommand(elements, matrix))
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    int rowOne = int.Parse(elements[1]);
    int colOne = int.Parse(elements[2]);
    int rowTwo = int.Parse(elements[3]);
    int colTwo = int.Parse(elements[4]);

    string temp = matrix[rowOne, colOne];
    matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
    matrix[rowTwo, colTwo] = temp;

    PrintMatrix(matrix);
}

void PrintMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }

        Console.WriteLine();
    }
}

static bool ValidCommand(string[] indexes, string[,] matrix)
{
    bool isValid = true;

    if (indexes[0] != "swap" || indexes.Length != 5)
    {
        return false;
    }

    if (!ValidIndex(int.Parse(indexes[1]), matrix.GetLength(0))
    || !ValidIndex(int.Parse(indexes[2]), matrix.GetLength(1))
    || !ValidIndex(int.Parse(indexes[3]), matrix.GetLength(0))
    || !ValidIndex(int.Parse(indexes[4]), matrix.GetLength(1)))
    {
        isValid = false;
    }

    return isValid;
}

static bool ValidIndex(int index, int indexLength)
{
    if (index < 0 || index >= indexLength)
    {
        return false;
    }

    return true;
}