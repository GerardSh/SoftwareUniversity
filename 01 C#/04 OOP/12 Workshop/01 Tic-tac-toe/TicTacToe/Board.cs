using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board : IBoard
    {
        Symbol[,] board;

        public Board()
            : this(3, 3)
        {
        }

        public Board(int rows, int columns)
        {
            if (rows != columns)
            {
                throw new ArgumentException("Rows should be equal to columns");
            }

            Rows = rows;
            Columns = columns;
            board = new Symbol[rows, columns];
        }

        public int Rows { get; }

        public int Columns { get; }

        public Symbol[,] BoardState => board;

        public Symbol GetRowSymbol(int row)
        {
            Symbol symbol = board[row, 0];

            if (symbol == Symbol.None)
            {
                return symbol;
            }

            for (int col = 1; col < Columns; col++)
            {
                if (board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetColumnSymbol(int column)
        {
            Symbol symbol = board[0, column];

            if (symbol == Symbol.None)
            {
                return symbol;
            }

            for (int row = 1; row < Rows; row++)
            {
                if (board[row, column] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTLBRSymbol()
        {
            Symbol symbol = board[0, 0];

            if (symbol == Symbol.None)
            {
                return symbol;
            }

            for (int row = 1; row < Rows; row++)
            {
                if (symbol != board[row, row])
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }
        public Symbol GetDiagonalTRBLSymbol()
        {
            Symbol symbol = board[0, Columns - 1];

            if (symbol == Symbol.None)
            {
                return symbol;
            }

            for (int row = 1; row < Rows; row++)
            {
                if (symbol != board[row, Columns - 1 - row])
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }
        public IEnumerable<Index> GetEmptyPositions()
        {
            var positions = new List<Index>();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (board[i, j] == Symbol.None)
                    {
                        positions.Add(new Index(i, j));
                    }
                }
            }

            return positions;
        }
        public bool IsFull()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (board[i, j] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Column < 0 || index.Row >= Rows || index.Column >= Columns)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            board[index.Row, index.Column] = symbol;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Symbol symbol = board[row, col];

                    if (symbol == Symbol.None)
                    {
                        sb.Append(".");
                    }
                    else
                    {
                        sb.Append(board[row, col]);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
