int n = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[n][];

for (int row = 0; row < n; row++)
{
    int[] rowLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

    jaggedArray[row] = new int[rowLine.Length];

    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        jaggedArray[row][col] = rowLine[col];
    }
}

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];
    int elementsRow = int.Parse(elements[1]);
    int elementsCol = int.Parse(elements[2]);
    int elementsValue = int.Parse(elements[3]);

    if (!ValidCordinates(jaggedArray, elementsRow, elementsCol))
    {
        Console.WriteLine($"Invalid coordinates");
        continue;
    }

    if (command == "Add")
    {
        jaggedArray[elementsRow][elementsCol] += elementsValue;
    }
    else if (command == "Subtract")
    {
        jaggedArray[elementsRow][elementsCol] -= elementsValue;
    }
}

foreach (var numbers in jaggedArray)
{
    foreach (int number in numbers)
    {
        Console.Write(number + " ");
    }

    Console.WriteLine();
}

bool ValidCordinates(int[][] jaggedArray, int elementsRow, int elementsCol)
{
    if (elementsRow < 0 || elementsRow >= jaggedArray.Length || elementsCol < 0 || elementsCol >= jaggedArray[elementsRow].Length)
    {
        return false;
    }

    return true;
}