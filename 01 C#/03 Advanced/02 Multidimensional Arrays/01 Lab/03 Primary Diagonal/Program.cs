int n = int.Parse(Console.ReadLine());

int rows = n;
int cols = n;

int count = 0;
int diagonalSum = 0;

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] elements = Console.ReadLine().Split();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);

        if (col == count)
        {
            diagonalSum += matrix[row, col];
        }
    }

    count++;
}

Console.WriteLine(diagonalSum);