using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var monsters = new Queue<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var soldiers = new Stack<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int killedMonsters = 0;

            while (monsters.Count > 0 && soldiers.Count > 0)
            {
                int monster = monsters.Dequeue();
                int soldier = soldiers.Pop();

                int result = soldier - monster;

                if (result >= 0)
                {
                    killedMonsters++;
                }

                if (result > 0 && soldiers.Count > 0)
                {
                    int temp = soldiers.Pop();
                    soldiers.Push(temp + result);
                }
                else if (result < 0)
                {
                    monsters.Enqueue(Math.Abs(result));
                }
            }

            if (monsters.Count == 0) 
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (soldiers.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");
        }
    }
}