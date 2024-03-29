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