int n = int.Parse(Console.ReadLine());

string[] matrix = NxnMatrix(n);

foreach (string element in matrix)
{
    Console.WriteLine(element);
}

static string[] NxnMatrix(int number)
{
    string[] matrix = new string[number];

    for (int i = 0; i < number; i++)
    {
        for (int j = 0; j < number; j++)
        {
            matrix[i] += number + " ";
        }
    }

    return matrix;
}