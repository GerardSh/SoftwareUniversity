int n = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[n][];

for (int i = 0; i < n; i++)
{
    int[] elements = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    jaggedArray[i] = elements;
}

for (int i = 0; i < jaggedArray.Length - 1; i++)
{
    if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
    {
        ModifyArray(jaggedArray, i, "*");
    }
    else
    {
        ModifyArray(jaggedArray, i, "/");
    }
}

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];
    int row = int.Parse(elements[1]);
    int col = int.Parse(elements[2]);
    int value = int.Parse(elements[3]);

    if (!ValidIndexes(jaggedArray, row, col))
    {
        continue;
    }

    if (command == "Add")
    {
        jaggedArray[row][col] += value;
    }
    else
    {
        jaggedArray[row][col] -= value;
    }
}

PrintArray(jaggedArray);

void PrintArray(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        Console.WriteLine(string.Join(" ", jaggedArray[i]));
    }
}

bool ValidIndexes(int[][] array, int row, int col)
{
    if (row < 0 || row >= array.Length || col < 0 || col >= array[row].Length)
    {
        return false;
    }

    return true;
}

void ModifyArray(int[][] jaggedArray, int startIndex, string modifier)
{
    for (int i = startIndex; i <= startIndex + 1; i++)
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            if (modifier == "*")
            {
                jaggedArray[i][j] *= 2;
            }
            else
            {
                jaggedArray[i][j] /= 2;
            }
        }
    }
}