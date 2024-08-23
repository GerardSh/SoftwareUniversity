using System;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
        }

        public void InitializeWallBorders()
        {
            InitializeHorizontal(0);
            InitializeHorizontal(TopY - 1);
            InitializeVertical(0);
            InitializeVertical(LeftX - 1);
        }

        void InitializeHorizontal(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        void InitializeVertical(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
    }
}