namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            const int pointsNeededToWin = 25;

            int n = int.Parse(Console.ReadLine());

            char[,] playingField = new char[n, n];

            int moleRow = 0;
            int moleCol = 0;
            int firstSRow = 0;
            int firstSCol = 0;
            int secondSRow = 0;
            int secondSCol = 0;
            int sCount = 0;

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    playingField[row, col] = currentRow[col];

                    if (currentRow[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }

                    if (currentRow[col] == 'S')
                    {
                        if (sCount++ == 0)
                        {
                            firstSRow = row;
                            firstSCol = col;
                        }
                        else
                        {
                            secondSRow = row;
                            secondSCol = col;
                        }
                    }
                }
            }

            string command;
            int collectedPoints = 0;

            while (collectedPoints < 25 && (command = Console.ReadLine()) != "End")
            {
                if (command == "up" && moleRow == 0
                    || command == "down" && moleRow == playingField.GetLength(0) - 1
                    || command == "left" && moleCol == 0
                    || command == "right" && moleCol == playingField.GetLength(1) - 1)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                playingField[moleRow, moleCol] = '-';

                if (command == "up")
                {
                    moleRow--;
                }
                else if (command == "down")
                {
                    moleRow++;
                }
                else if (command == "left")
                {
                    moleCol--;
                }
                else if (command == "right")
                {
                    moleCol++;
                }

                if (playingField[moleRow, moleCol] == 'S')
                {
                    playingField[moleRow, moleCol] = '-';

                    if (moleRow == firstSRow && moleCol == firstSCol)
                    {
                        moleRow = secondSRow;
                        moleCol = secondSCol;
                    }
                    else
                    {
                        moleRow = firstSRow;
                        moleCol = firstSCol;
                    }

                    collectedPoints -= 3;
                }
                else if (playingField[moleRow, moleCol] != '-')
                {
                    collectedPoints += playingField[moleRow, moleCol] - 48;
                }

                playingField[moleRow, moleCol] = 'M';
            }

            if (collectedPoints >= pointsNeededToWin)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {collectedPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {collectedPoints} points.");
            }

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write(playingField[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}