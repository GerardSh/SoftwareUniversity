namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] playground = new string[dimensions[0], dimensions[1]];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < playground.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int col = 0; col < playground.GetLength(1); col++)
                {
                    playground[row, col] = currentRow[col];

                    if (currentRow[col] == "B")
                    {
                        playerRow = row;
                        playerCol = col;

                        playground[playerRow, playerCol] = "-";
                    }
                }
            }

            int movesCount = 0;
            int touchesCount = 0;

            string command;

            while ((command = Console.ReadLine()) != "Finish")
            {

                if (command == "up" && playerRow == 0
                    || command == "down" && playerRow == playground.GetLength(0) - 1
                    || command == "left" && playerCol == 0
                    || command == "right" && playerCol == playground.GetLength(1) - 1)
                {
                    continue;
                }

                if (command == "up" && playground[playerRow - 1, playerCol] == "O"
                    || command == "down" && playground[playerRow + 1, playerCol] == "O"
                    || command == "left" && playground[playerRow, playerCol - 1] == "O"
                    || command == "right" && playground[playerRow, playerCol + 1] == "O")
                {
                    continue;
                }

                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }

                movesCount++;

                if (playground[playerRow, playerCol] == "P")
                {
                    playground[playerRow, playerCol] = "-";

                    if (++touchesCount == 3)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchesCount} Moves made: {movesCount}");
        }
    }
}
