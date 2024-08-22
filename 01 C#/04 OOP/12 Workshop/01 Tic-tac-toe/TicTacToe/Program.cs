using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Program
    {
        static Simulation Simulation { get; } = new Simulation();

        public static void Main()
        {
            Console.Title = "TicTacToe 1.0";

            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== TicTacToe 1.0 ===");
                    Console.WriteLine("1. Player vs Player");
                    Console.WriteLine("2. Player vs Random");
                    Console.WriteLine("3. Random vs Player");
                    Console.WriteLine("4. Random vs Random");
                    Console.WriteLine("5. Player vs AI");
                    Console.WriteLine("6. AI vs Player");
                    Console.WriteLine("7. AI vs AI");
                    Console.WriteLine("8. Simulate Random vs Random");
                    Console.WriteLine("9. Simulate Random vs AI");
                    Console.WriteLine("10. Simulate AI vs Random");
                    Console.WriteLine("11. Simulate AI vs AI");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine();
                    Console.Write("Please enter number [0-11]: ");
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        return;
                    }
                    else if (input == "1")
                    {
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                    }
                    else if (input == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                    }
                    else if (input == "3")
                    {
                        PlayGame(new RandomPlayer(), new ConsolePlayer());
                    }
                    else if (input == "4")
                    {
                        PlayGame(new RandomPlayer(), new RandomPlayer());
                    }
                    else if (input == "5")
                    {
                        PlayGame(new ConsolePlayer(), new AiPlayer());
                    }
                    else if (input == "6")
                    {
                        PlayGame(new AiPlayer(), new ConsolePlayer());
                    }
                    else if (input == "7")
                    {
                        PlayGame(new AiPlayer(), new AiPlayer());
                    }
                    else if (input == "8")
                    {
                        Simulation.Simulate(new RandomPlayer(), new RandomPlayer(), 1000);
                    }
                    else if (input == "9")
                    {
                        Simulation.Simulate(new RandomPlayer(), new AiPlayer(), 10);
                    }
                    else if (input == "10")
                    {
                        Simulation.Simulate(new AiPlayer(), new RandomPlayer(), 10);
                    }
                    else if (input == "11")
                    {
                        Simulation.Simulate(new AiPlayer(), new AiPlayer(), 10);
                    }
                    else
                    {
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Press [enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }    

        public static void PlayGame(IPlayer player1, IPlayer player2)
        {
            var game = new TicTacToeGame(player1, player2);

            var result = game.Play();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{result.Board}");
            Console.WriteLine("Game over!");

            if (result.Winner == Symbol.None)
            {
                Console.WriteLine("The game end in a draw");
            }
            else
            {
                Console.WriteLine($"Winner is: {result.Winner}");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
