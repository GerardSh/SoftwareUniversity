namespace SimpleSnake
{
    using Utilities;
    using SimpleSnake.GameObjects;
    using System.Collections.Generic;
    using System.Threading;
    using SimpleSnake.Core;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // ConsoleWindow.CustomizeConsole();
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;

            Wall wall = new Wall(20, 20);

            wall.InitializeWallBorders();

            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake, wall);

            engine.Run();
        }
    }
}
