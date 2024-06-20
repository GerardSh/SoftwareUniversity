namespace ConsoleApp
{
    public class Program
    {
        static int snakeRow = -1;
        static int snakeCol = -1;
        static int firstBurrowRow = -1;
        static int firstBurrowCol = -1;
        static int secondBurrowRow = -1;
        static int secondBurrowCol = -1;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    territory[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (currentRow[col] == 'B')
                    {
                        if (firstBurrowCol == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            string command;
            int foodEaten = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                territory[snakeRow, snakeCol] = '.';

                if (OutsideBoundaries(territory, command))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                ChangePosition(territory, command);

                if (territory[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';

                    if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }

                territory[snakeRow, snakeCol] = 'S';

                if (foodEaten == 10)
                {
                    break;
                }
            }

            if (foodEaten == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangePosition(char[,] territory, string command)
        {

            if (command == "up")
            {
                snakeRow--;
            }
            else if (command == "down")
            {
                snakeRow++;
            }
            else if (command == "left")
            {
                snakeCol--;
            }
            else if (command == "right")
            {
                snakeCol++;
            }
        }
        private static bool OutsideBoundaries(char[,] territory, string command)
        {
            if (command == "up" && snakeRow == 0
                || command == "down" && snakeRow == territory.GetLength(0) - 1
                || command == "left" && snakeCol == 0
                || command == "right" && snakeCol == territory.GetLength(1) - 1)
            {
                return true;
            }

            return false;
        }
    }
}