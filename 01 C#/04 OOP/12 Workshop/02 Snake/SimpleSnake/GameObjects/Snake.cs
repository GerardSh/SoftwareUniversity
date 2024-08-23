using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        const char SnakeSymbol = '\u25CF';
        Queue<Point> snakeElements;
        readonly Food[] foods;
        readonly Wall wall;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;

            snakeElements = new Queue<Point>();
            foods = new Food[]
            {
                new FoodDollar(wall),
                new FoodAsterisk(wall),
                new FoodHesh(wall)
            };

            Speed = 300;
            CreateSnake();
        }

        public int Count => snakeElements.Count;

        public int Speed { get; private set; }

        public int TotalPointsEarned { get; private set; }

        public bool TryMove(Point direction)
        {
            Point snakeHead = snakeElements.Last();

            int nextLeftX = snakeHead.LeftX + direction.LeftX;
            int nextTopY = snakeHead.TopY + direction.TopY;

            Point lastPoint = snakeElements.Dequeue();

            bool isSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isSnake)
            {
                return false;
            }

            if (IsWall(nextLeftX, nextTopY))
            {
                return false;
            }

            bool isFood = foods[foodIndex].LeftX == nextLeftX && foods[foodIndex].TopY == nextTopY;

            Point snakeNewHeadPoint = new Point(nextLeftX, nextTopY);
            snakeElements.Enqueue(snakeNewHeadPoint);

            if (isFood)
            {
                bool gameOver = Eat(snakeNewHeadPoint, direction);

                if (gameOver)
                {
                    return false;
                }

                Console.Beep();

                if (Speed >= 100)
                {
                    Speed -= 10;
                }
                else if (Speed >= 70)
                {
                    Speed -= 1;
                }
            }
            else
            {
                snakeNewHeadPoint.Draw(SnakeSymbol);
            }

            if (!snakeElements.Any(x => x.LeftX == lastPoint.LeftX && x.TopY == lastPoint.TopY))
            {
                lastPoint.Draw(' ');
            }

            return true;
        }

        bool IsWall(int nextLeftX, int nextTopY) =>
            nextLeftX <= 0
         || nextTopY <= 0
         || nextLeftX >= wall.LeftX - 1
         || nextTopY >= wall.TopY - 1;


        bool Eat(Point currentHead, Point direction)
        {
            Food food = foods[foodIndex];

            currentHead.Draw('@');

            // The below will ensure that the snake will grow from the head with the given food score:
            //for (int i = 1; i <= food.Points; i++)
            //{
            //    Point pointToAdd = new Point(currentHead.LeftX, currentHead.TopY);

            //    if (direction.LeftX == -1)
            //    {
            //        pointToAdd.LeftX -= i;
            //    }
            //    else if (direction.LeftX == 1)
            //    {
            //        pointToAdd.LeftX += i;
            //    }
            //    else if (direction.TopY == -1)
            //    {
            //        pointToAdd.TopY -= i;
            //    }
            //    else if (direction.TopY == 1)
            //    {
            //        pointToAdd.TopY += i;
            //    }

            //    if (IsWall(pointToAdd.LeftX, pointToAdd.TopY))
            //    {
            //        return true;
            //    }

            //    snakeElements.Enqueue(pointToAdd);
            //    pointToAdd.Draw(SnakeSymbol);
            //}

            // The snake will grow from the tail
            Point lastElement = snakeElements.First();
            Queue<Point> newSnake = new Queue<Point>();

            for (int i = 0; i < food.Points; i++)
            {
                newSnake.Enqueue(lastElement);
            }

            int snakeElementsCount = snakeElements.Count;

            for (int i = 0; i < snakeElementsCount; i++)
            {
                newSnake.Enqueue(snakeElements.Dequeue());
            }

            snakeElements = newSnake;
            // End of tail grow block

            TotalPointsEarned += food.Points;
            foodIndex = GetRandomIndex();
            foods[foodIndex].SetRandomPosition(snakeElements);

            return false;
        }

        void CreateSnake()
        {
            snakeElements = new Queue<Point>();

            for (int i = 1; i <= 6; i++)
            {
                Point point = new Point(i, 1);

                snakeElements.Enqueue(point);
                point.Draw(SnakeSymbol);
            }

            foodIndex = GetRandomIndex();
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        int GetRandomIndex() => new Random().Next(0, foods.Length);
    }
}

