using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        Wall wall;
        char symbol;
        Random random;

        protected Food(Wall wall, char symbol, int points)
            : base(0, 0)
        {
            this.wall = wall;
            this.symbol = symbol;
            Points = points;
            random = new Random();
        }

        public int Points { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            do
            {
                LeftX = random.Next(1, wall.LeftX - 1);
                TopY = random.Next(1, wall.TopY - 1);
            }
            while (snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY));

            Console.BackgroundColor=ConsoleColor.Green;
            Draw(symbol);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
