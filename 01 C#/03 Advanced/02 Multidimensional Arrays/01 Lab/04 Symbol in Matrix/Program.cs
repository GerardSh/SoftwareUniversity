int n = int.Parse(Console.ReadLine());

int rows = n;
int cols = n;

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] chars = Console.ReadLine()
        .ToCharArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = chars[col];
    }
}

char symbol = char.Parse(Console.ReadLine());

string position = null;
bool isFound = false;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row, col] == symbol)
        {
            position = $"({row}, {col})";
            isFound = true;
            break;
        }
    }

    if (isFound)
    {
        break;
    }
}

if (position != null)
{
    Console.WriteLine(position);
}
else
{
    Console.WriteLine($"{symbol} does not occur in the matrix");
}