using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public class ConsolePlayer : IPlayer
    {
        public Index Play(Board board, Symbol symbol)
        {
            Console.Clear();
            Console.WriteLine(board);

            while (true)
            {
                Console.Write($"{symbol} Please enter position (0,0): ");

                var input = Console.ReadLine();
                Index position;

                try
                {
                    position = new Index(input);
                }
                catch
                {
                    Console.WriteLine("Invalid position format!");
                    continue;
                }

                if (!board.GetEmptyPositions().Any(x => x.Equals(position)))
                {
                    Console.WriteLine("This position is not available!");
                    continue;
                }

                return position;
            }
        }
    }
}
