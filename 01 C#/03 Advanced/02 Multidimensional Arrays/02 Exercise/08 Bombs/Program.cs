using System.Text;

int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];

CreatingMatrix(matrix);

string[] bombData = Console.ReadLine()
    .Split();

for (int i = 0; i < bombData.Length; i++)
{
    int[] bombLocation = bombData[i]
        .Split(",")
        .Select(int.Parse)
        .ToArray();

    int row = bombLocation[0];
    int col = bombLocation[1];

    int bombPower = matrix[row, col];

    if (bombPower <= 0)
    {
        continue;
    }

    if (ValidExplosion(row - 1, col, matrix))
    {
        matrix[row - 1, col] -= bombPower;
    }
    if (ValidExplosion(row - 1, col - 1, matrix))
    {
        matrix[row - 1, col - 1] -= bombPower;
    }
    if (ValidExplosion(row - 1, col + 1, matrix))
    {
        matrix[row - 1, col + 1] -= bombPower;
    }
    if (ValidExplosion(row, col + 1, matrix))
    {
        matrix[row, col + 1] -= bombPower;
    }
    if (ValidExplosion(row, col - 1, matrix))
    {
        matrix[row, col - 1] -= bombPower;
    }
    if (ValidExplosion(row + 1, col, matrix))
    {
        matrix[row + 1, col] -= bombPower;
    }
    if (ValidExplosion(row + 1, col - 1, matrix))
    {
        matrix[row + 1, col - 1] -= bombPower;
    }
    if (ValidExplosion(row + 1, col + 1, matrix))
    {
        matrix[row + 1, col + 1] -= bombPower;
    }

    matrix[row, col] = 0;
}

int aliveCells = 0;
int sum = 0;
StringBuilder sb = new StringBuilder();

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (matrix[row, col] > 0)
        {
            aliveCells++;
            sum += matrix[row, col];
        }

        sb.Append(matrix[row, col] + " ");
    }

    sb.AppendLine();
}

Console.WriteLine("Alive cells: " + aliveCells);
Console.WriteLine("Sum: " + sum);
Console.WriteLine(sb);

bool ValidExplosion(int row, int col, int[,] matrix)
{
    return row >= 0 && row < matrix.GetLength(0)
         && col >= 0 && col < matrix.GetLength(1)
         && matrix[row, col] > 0;
};

static void CreatingMatrix(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        string[] line = Console.ReadLine().Split();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = int.Parse(line[col]);
        }
    }
}