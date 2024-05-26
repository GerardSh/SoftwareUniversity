using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var chalanges = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            while (tools.Any() && substances.Any())
            {
                int tool = tools.Dequeue();
                int substance = substances.Pop();

                int result = tool * substance;

                if (chalanges.Contains(result))
                {
                    chalanges.Remove(result);
                }
                else
                {
                    tools.Enqueue(tool + 1);

                    if (substance - 1 > 0)
                    {
                        substances.Push(substance - 1);
                    }
                }
            }

            if (chalanges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine("Tools: " + string.Join(", ", tools));
            }

            if (substances.Any())
            {
                Console.WriteLine("Substances: " + string.Join(", ", substances));
            }

            if (chalanges.Any())
            {
                Console.WriteLine("Chalanges: " + string.Join(", ", chalanges));
            }
        }
    }
}