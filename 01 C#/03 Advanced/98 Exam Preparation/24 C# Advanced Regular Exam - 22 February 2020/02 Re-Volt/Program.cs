namespace ConsoleApp
{
    public class Program
    {
        static int playerRow = -1;
        static int playerCol = -1;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var finishedLineReached = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                ChangePosition(matrix, command);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    ChangePosition(matrix, command);
                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    command = command == "up" ? "down" : command == "down" ? "up" : command == "left" ? "right" : "left";

                    ChangePosition(matrix, command);
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    finishedLineReached = true;
                }

                matrix[playerRow, playerCol] = 'f';

                if (finishedLineReached)
                {
                    break;
                }
            }

            if (finishedLineReached)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangePosition(char[,] matrix, string command)
        {
            if (command == "up")
            {
                playerRow--;

                if (playerRow == -1)
                {
                    playerRow = matrix.GetLength(0) - 1;
                }
            }
            else if (command == "down")
            {
                playerRow++;

                if (playerRow == matrix.GetLength(0))
                {
                    playerRow = 0;
                }
            }
            else if (command == "left")
            {
                playerCol--;

                if (playerCol == -1)
                {
                    playerCol = matrix.GetLength(1) - 1;
                }
            }
            else if (command == "right")
            {
                playerCol++;

                if (playerCol == matrix.GetLength(1))
                {
                    playerCol = 0;
                }
            }
        }
    }
}