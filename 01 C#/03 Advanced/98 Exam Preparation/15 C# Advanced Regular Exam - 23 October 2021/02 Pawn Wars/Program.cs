using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Dictionary<int, char> colMap = new Dictionary<int, char>()
            {
                {0, 'a'},
                {1, 'b'},
                {2, 'c'},
                {3, 'd'},
                {4, 'e'},
                {5, 'f'},
                {6, 'g'},
                {7, 'h'},
            };

            char[,] chessBoard = new char[8, 8];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    if (currentRow[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (currentRow[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }

                    chessBoard[row, col] = '-';
                }
            }

            bool whiteWon = false;
            bool blackWon = false;

            while (true)
            {
                if (whiteRow - 1 == blackRow)
                {
                    if (whiteCol - 1 == blackCol)
                    {
                        whiteWon = true;
                    }
                    else if (whiteCol + 1 == blackCol)
                    {
                        whiteWon = true;
                    }

                    if (whiteWon)
                    {
                        whiteRow--;
                        whiteCol = blackCol;
                        break;
                    }
                }

                if (--whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {colMap[whiteCol]}8.");
                    return;
                }

                if (blackRow + 1 == whiteRow)
                {
                    if (blackCol - 1 == whiteCol)
                    {
                        blackWon = true;

                    }
                    else if (blackCol + 1 == whiteCol)
                    {
                        blackWon = true;
                    }

                    if (blackWon)
                    {
                        blackRow++;
                        blackCol = whiteCol;
                        break;
                    }
                }

                if (++blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colMap[blackCol]}1.");
                    return;
                }
            }

            if (whiteWon)
            {
                Console.WriteLine($"Game over! White capture on {colMap[whiteCol]}{8 - whiteRow}.");
            }

            if (blackWon)
            {
                Console.WriteLine($"Game over! Black capture on {colMap[blackCol]}{8 - blackRow}.");
            }
        }
    }
}