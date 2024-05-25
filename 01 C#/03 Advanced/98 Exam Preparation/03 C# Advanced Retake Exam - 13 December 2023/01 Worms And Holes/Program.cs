using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var worms = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var holes = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int matchesCount = 0;
            int initialWormsCount = worms.Count;

            while (worms.Count > 0 && holes.Count > 0)
            {
                int worm = worms.Pop();
                int hole = holes.Dequeue();

                if (worm == hole)
                {
                    matchesCount++;
                    continue;
                }
                else
                {
                    worm -= 3;
                }

                if (worm > 0)
                {
                    worms.Push(worm);
                }
            }

            if (matchesCount > 0)
            {
                Console.WriteLine($"Matches: {matchesCount}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0)
            {
                if (initialWormsCount == matchesCount)
                {
                    Console.WriteLine("Every worm found a suitable hole!");
                }
                else
                {
                    Console.WriteLine("Worms left: none");
                }
            }
            else if (worms.Count > 0)
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }
}