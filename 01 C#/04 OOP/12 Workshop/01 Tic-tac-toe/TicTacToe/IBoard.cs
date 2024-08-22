using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IBoard
    {
        int Rows { get; }

        int Columns { get; }

        Symbol[,] BoardState { get; }

        bool IsFull();

        void PlaceSymbol(Index index, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbol(int row);

        Symbol GetColumnSymbol(int column);

        Symbol GetDiagonalTLBRSymbol();

        Symbol GetDiagonalTRBLSymbol();
    }
}
