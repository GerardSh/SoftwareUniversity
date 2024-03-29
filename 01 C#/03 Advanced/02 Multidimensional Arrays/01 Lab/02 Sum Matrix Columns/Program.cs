string[] elements = Console.ReadLine().Split(", ");

int rows = int.Parse(elements[0]);
int cols = int.Parse(elements[1]);

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    elements = Console.ReadLine().Split();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = int.Parse(elements[col]);
    }
}

for (int col = 0; col < cols; col++)
{
    int sum = 0;

    for (int row = 0; row < rows; row++)
    {
        sum += matrix[row, col];
    }

    Console.WriteLine(sum);
}