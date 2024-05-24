using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> pies = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int count = pies.Count;

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int currentContestant = contestants.Peek();
                int currentPie = pies.Peek();

                int result = currentPie - currentContestant;

                if (result == 1)
                {
                    contestants.Dequeue();

                    if (pies.Count > 1)
                    {
                        pies.Pop();
                        int temp = pies.Pop();
                        pies.Push(temp + result);
                    }
                    else
                    {
                        pies.Pop();
                        pies.Push(result);
                    }
                }
                else if (result == 0)
                {
                    pies.Pop();
                    contestants.Dequeue();
                }
                else if (result < 0)
                {
                    pies.Pop();
                    contestants.Dequeue();
                    contestants.Enqueue(Math.Abs(result));
                }
                else if (result > 1)
                {
                    pies.Pop();
                    pies.Push(result);
                    contestants.Dequeue();
                }
            }

            if (contestants.Count > 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.WriteLine("Contestants left: " + string.Join(", ", contestants));
            }
            else if (pies.Count > 0)
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine("Pies left: " + string.Join(", ", pies));
            }
            else
            {
                Console.WriteLine("We have a champion!");
            }

        }
    }
}
//2




using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> pies = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int count = pies.Count;

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int currentContestant = contestants.Dequeue();
                int currentPie = pies.Pop();

                int result = Math.Abs(currentContestant - currentPie);

                if (currentContestant >= currentPie)
                {
                    if (result > 0)
                    {
                        contestants.Enqueue(result);
                    }
                    continue;
                }

                if (pies.Count == 0)
                {
                    pies.Push(result);
                    continue;
                }

                if (result == 1)
                {
                    int temp = pies.Pop();
                    pies.Push(temp + 1);
                    continue;
                }

                pies.Push(result);

            }

            if (contestants.Count > 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                    Console.WriteLine("Pies left: " + string.Join(", ", pies));
            }
            else if (pies.Count > 0)
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine("Pies left: " + string.Join(", ", pies));
            }
            else
            {
                Console.WriteLine("We have a champion!");
            }

        }
    }
}