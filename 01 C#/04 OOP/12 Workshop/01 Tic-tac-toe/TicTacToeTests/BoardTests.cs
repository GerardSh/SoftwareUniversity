using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace TicTacToeTests
{
    public class BoardTests
    {
        IBoard board;

        [SetUp]
        public void Setup()
        {
            board = new Board(3, 3);
        }

        [Test]
        public void IsFullMethodShouldReturnTrueForFullBoard()
        {
            Assert.IsFalse(board.IsFull());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaceSymbol(new Index(i, j), Symbol.X);
                }
            }

            Assert.IsTrue(board.IsFull());
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetRowSymbolMethodShouldWorkCorrectly(Symbol symbol)
        {
            for (int i = 0; i < board.Columns; i++)
            {
                Assert.That(board.GetRowSymbol(2), Is.EqualTo(Symbol.None));

                board.PlaceSymbol(new Index(2, i), symbol);
            }

            Assert.That(board.GetRowSymbol(2), Is.EqualTo(symbol));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetColumnSymbolMethodShouldWorkCorrectly(Symbol symbol)
        {

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.That(board.GetColumnSymbol(2), Is.EqualTo(Symbol.None));

                board.PlaceSymbol(new Index(i, 2), symbol);
            }

            Assert.That(board.GetColumnSymbol(2), Is.EqualTo(symbol));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetDiagonalTLBRSymbolMethodShouldWorkCorrectly(Symbol symbol)
        {

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.That(board.GetDiagonalTLBRSymbol(), Is.EqualTo(Symbol.None));

                board.PlaceSymbol(new Index(i, i), symbol);
            }

            Assert.That(board.GetDiagonalTLBRSymbol(), Is.EqualTo(symbol));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetDiagonalTRBLSymbolMethodShouldWorkCorrectly(Symbol symbol)
        {

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.That(board.GetDiagonalTRBLSymbol(), Is.EqualTo(Symbol.None));

                board.PlaceSymbol(new Index(i, board.Rows - 1 - i), symbol);
            }

            Assert.That(board.GetDiagonalTRBLSymbol(), Is.EqualTo(symbol));
        }

        [Test]
        public void GetEmptyPositionsMethodShouldReturnAllPositionsForEmptyBoard()
        {
            var positions = board.GetEmptyPositions();

            Assert.That(positions.Count, Is.EqualTo(3 * 3));
        }

        [Test]
        public void GetEmptyPositionsMethodShouldReturnCorrectNumberOfPositions()
        {
            board.PlaceSymbol(new Index(0, 0), Symbol.X);
            board.PlaceSymbol(new Index(2, 2), Symbol.O);

            var positions = board.GetEmptyPositions();

            Assert.That(positions.Count, Is.EqualTo(3 * 3 - 2));
        }

        [Test]
        public void PlaceSymbolMethodShouldWorkCorrectly()
        {
            board.PlaceSymbol(new Index(0, 0), Symbol.X);
            board.PlaceSymbol(new Index(2, 2), Symbol.O);

            Symbol[,] boardMatrix = this.board.BoardState;

            Assert.That(boardMatrix[0, 0], Is.EqualTo(Symbol.X));
            Assert.That(boardMatrix[1, 1], Is.EqualTo(Symbol.None));
            Assert.That(boardMatrix[2, 2], Is.EqualTo(Symbol.O));

            Assert.Throws<IndexOutOfRangeException>(() => board.PlaceSymbol(new Index(-1, 0), Symbol.X));
            Assert.Throws<IndexOutOfRangeException>(() => board.PlaceSymbol(new Index(3, 0), Symbol.X));
            Assert.Throws<IndexOutOfRangeException>(() => board.PlaceSymbol(new Index(0, -1), Symbol.X));
            Assert.Throws<IndexOutOfRangeException>(() => board.PlaceSymbol(new Index(0, 3), Symbol.X));
        }

        [Test]
        public void ToStringMethodShouldWorkCorrectly()
        {
            board.PlaceSymbol(new Index(0, 0), Symbol.X);
            board.PlaceSymbol(new Index(2, 2), Symbol.O);

            Symbol[,] boardMatrix = this.board.BoardState;

            var sb = new StringBuilder();

            sb.AppendLine("X..");
            sb.AppendLine("...");
            sb.AppendLine("..O");

            Assert.That(board.ToString(), Is.EqualTo(sb.ToString()));
        }
    }
}
