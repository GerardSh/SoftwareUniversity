

namespace ConsoleApp
{
    public class Program
    {
        static int beeRow = 0;
        static int beeCol = 0;

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

                    if (currentRow[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command;
            int polinatedFlowersCount = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                if (OutsideBoundaries(territory, command))
                {
                    break;
                }

                if (territory[beeRow, beeCol] == 'O')
                {
                    if (OutsideBoundaries(territory, command))
                    {
                        break;
                    }
                }

                if (territory[beeRow, beeCol] == 'f')
                {
                    polinatedFlowersCount++;
                }

                territory[beeRow, beeCol] = 'B';
            }

            if (polinatedFlowersCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowersCount} flowers!");
            }

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
            territory[beeRow, beeCol] = '.';

            if (command == "up")
            {
                beeRow--;
            }
            else if (command == "down")
            {
                beeRow++;
            }
            else if (command == "left")
            {
                beeCol--;
            }
            else if (command == "right")
            {
                beeCol++;
            }
        }

        private static bool OutsideBoundaries(char[,] territory, string command)
        {
            if (command == "up" && beeRow == 0
                || command == "down" && beeRow == territory.GetLength(0) - 1
                || command == "left" && beeCol == 0
                || command == "right" && beeCol == territory.GetLength(1) - 1)
            {
                Console.WriteLine("The bee got lost!");

                territory[beeRow, beeCol] = '.';

                return true;
            }

            ChangePosition(territory, command);

            return false;
        }
    }
}