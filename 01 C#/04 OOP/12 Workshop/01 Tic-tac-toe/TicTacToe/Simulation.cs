using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Simulation
    {
        public int[] Simulate(IPlayer player1, IPlayer player2, int count)
        {
            int x = 0, o = 0, draw = 0;
            int firstWinner = 0, secondWinner = 0;
            var first = player1;
            var second = player2;

            for (int i = 0; i < count; i++)
            {
                var game = new TicTacToeGame(first, second);
                var result = game.Play();

                if (result.Winner == Symbol.X) x++;
                if (result.Winner == Symbol.O) o++;
                if (result.Winner == Symbol.None) draw++;
                if (result.Winner == Symbol.X && first == player1) firstWinner++;
                if (result.Winner == Symbol.O && first == player1) secondWinner++;
                if (result.Winner == Symbol.X && first == player2) secondWinner++;
                if (result.Winner == Symbol.O && first == player2) firstWinner++;

                (first, second) = (second, first);
            }

            Console.WriteLine("Games played:");
            Console.WriteLine($"Games won by X: {x}");
            Console.WriteLine($"Games won by O: {o}");
            Console.WriteLine($"Draw games: {draw}");
            Console.WriteLine($"{player1.GetType().Name}: won games: {firstWinner}");
            Console.WriteLine($"{player2.GetType().Name}: won games: {secondWinner}");

            return new int[] { firstWinner, secondWinner };
        }
    }
}
