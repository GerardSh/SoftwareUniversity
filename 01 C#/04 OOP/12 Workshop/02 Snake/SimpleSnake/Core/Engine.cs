using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine
    {
        Direction direction;
        Dictionary<Direction, Point> pointDirections;
        Snake snake;
        Wall wall;

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;

            direction = Direction.Right;

            pointDirections = new Dictionary<Direction, Point>()
            {
                {Direction.Left, new Point(-1,0) },
                {Direction.Right, new Point(1,0) },
                {Direction.Up, new Point(0,-1) },
                {Direction.Down, new Point(0,1) },
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetDirection();
                }

                bool tryMove = snake.TryMove(pointDirections[direction]);

                if (!tryMove)
                {
                    Console.Beep();
                    Console.SetCursorPosition(wall.LeftX / 2 - 5, wall.TopY / 2);
                    Console.WriteLine("Game Over!");
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(wall.LeftX / 2 - 5, wall.TopY / 2);
                    Console.WriteLine($"Points earned {snake.TotalPointsEarned}");
                    Console.WriteLine($"Snake size {snake.Count + 1}");

                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Whould you like to continue? y/n");
                    string input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Clear();
                        StartUp.Main();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                Thread.Sleep(snake.Speed);
            }
        }

        void GetDirection()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
