using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public class AiPlayer : IPlayer
    {

        public AiPlayer()
        {
            WinnerLogic = new GameWinnerLogic();
        }

        public GameWinnerLogic WinnerLogic { get; }

        public Index Play(Board board, Symbol symbol)
        {
            List<Index> bestMoves = new List<Index>();
            Index bestMove = null;
            int bestMoveValue = -1000;
            var moves = board.GetEmptyPositions();

            foreach (var move in moves)
            {
                board.PlaceSymbol(move, symbol);
                var value = MiniMax(board, symbol, symbol == Symbol.X ? Symbol.O : Symbol.X);
                board.PlaceSymbol(move, Symbol.None);

                if (value > bestMoveValue)
                {
                    bestMove = move;
                    bestMoveValue = value;
                    bestMoves.Clear();
                    bestMoves.Add(move);
                }

                if (value == bestMoveValue)
                {
                    bestMoves.Add(move);
                }
            }

            return bestMoves[new Random().Next(bestMoves.Count)];
        }

        private int MiniMax(Board board, Symbol player, Symbol currentPlayer)
        {
            if (WinnerLogic.IsGameOver(board))
            {
                var winner = WinnerLogic.GetWinner(board);

                if (winner == player) return 1;
                else if (winner == Symbol.None) return 0;
                else return -1;
            }

            var bestValue = player == currentPlayer ? -100 : 100;
            var options = board.GetEmptyPositions();

            foreach (var option in options)
            {
                board.PlaceSymbol(option, currentPlayer);

                var value = MiniMax(board, player, currentPlayer == Symbol.O ? Symbol.X : Symbol.O);

                board.PlaceSymbol(option, Symbol.None);
                bestValue = currentPlayer == player ?
                    Math.Max(bestValue, value) :
                    Math.Min(bestValue, value);
            }

            return bestValue;
        }
    }
}
