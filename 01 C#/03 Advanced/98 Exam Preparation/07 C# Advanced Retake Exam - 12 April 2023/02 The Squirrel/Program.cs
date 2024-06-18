public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var commands = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

        char[,] field = new char[n, n];

        int squirrelRow = -1;
        int squirrelCol = -1;

        for (int row = 0; row < field.GetLength(0); row++)
        {
            string currentRow = Console.ReadLine();

            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = currentRow[col];

                if (currentRow[col] == 's')
                {
                    squirrelRow = row;
                    squirrelCol = col;

                    field[row, col] = '*';
                }
            }
        }

        int collectedHazelnuts = 0;

        while (commands.Any())
        {
            string command = commands.Dequeue();

            if (command == "up")
            {
                squirrelRow--;
            }
            else if (command == "down")
            {
                squirrelRow++;
            }
            else if (command == "left")
            {
                squirrelCol--;
            }
            else if (command == "right")
            {
                squirrelCol++;
            }

            if (!IsInsideField(field, squirrelRow, squirrelCol))
            {
                Console.WriteLine("The squirrel is out of the field.");
                break;
            }

            if (field[squirrelRow, squirrelCol] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                break;
            }

            if (field[squirrelRow, squirrelCol] == 'h')
            {
                if (++collectedHazelnuts == 3)
                {
                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                    break;
                }

                field[squirrelRow, squirrelCol] = '*';
            }

            if (commands.Count == 0)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
        }

        Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
    }

    private static bool IsInsideField(char[,] field, int row, int col) => row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
}