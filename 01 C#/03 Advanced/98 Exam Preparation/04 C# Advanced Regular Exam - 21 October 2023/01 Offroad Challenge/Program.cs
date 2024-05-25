using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var fuel = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var consumptionIndexes = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var fuelNeeded = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int altitude = 1;

            bool topReached = true;

            while (fuel.Count > 0 && fuelNeeded.Count > 0)
            {
                int currentFuel = fuel.Pop();
                int currentConsumptionIndex = consumptionIndexes.Dequeue();
                int currentFuelNeeded = fuelNeeded.Dequeue();

                int result = currentFuel - currentConsumptionIndex;

                if (result < currentFuelNeeded)
                {
                    Console.WriteLine($"John did not reach: Altitude {altitude--}");
                    topReached = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"John has reached: Altitude {altitude++}");
                }
            }

            if (!topReached)
            {
                Console.WriteLine("John failed to reach the top.");

                if (altitude == 0)
                {
                    Console.WriteLine("John didn't reach any altitude.");
                }
                else
                {
                    Console.Write("Reached altitudes: Altitude 1");

                    for (int i = 2; i <= altitude; i++)
                    {
                        Console.Write($", Altitude {i}");
                    }
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}