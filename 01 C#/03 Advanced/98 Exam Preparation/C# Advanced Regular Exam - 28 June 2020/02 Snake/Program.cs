namespace ConsoleApp
{
    public class Program
    {
        static int snakeRow = -1;
        static int snakeCol = -1;

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

                ChangePosition(command);

                if (territory[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';

                    for (int row = 0; row < territory.GetLength(0); row++)
                    {
                        var secondBurrowFound = false;

                        for (int col = 0; col < territory.GetLength(1); col++)
                        {
                            if (territory[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;
                                secondBurrowFound = true;
                                break;
                            }
                        }

                        if (secondBurrowFound)
                        {
                            break;
                        }
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

        private static void ChangePosition(string command)
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