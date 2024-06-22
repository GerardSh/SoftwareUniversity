//09:00
namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var packages = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var couriers = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalWeight = 0;

            while (couriers.Any() && packages.Any())
            {
                int currentPackage = packages.Pop();
                int currentCourier = couriers.Dequeue();

                int sum = currentCourier - currentPackage;

                if (sum >= 0)
                {
                    totalWeight += currentPackage;

                    int newSum = currentCourier - currentPackage * 2;

                    if (newSum > 0)
                    {
                        couriers.Enqueue(newSum);
                    }
                }
                else if (sum < 0)
                {
                    currentPackage -= currentCourier;
                    packages.Push(currentPackage);
                    totalWeight += currentCourier;
                }
            }

            Console.WriteLine($"Total weight: {totalWeight} kg");

            if (packages.Count == 0 && couriers.Count == 0)
            {
                Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
            }
            else if (packages.Count > 0 && couriers.Count == 0)
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(",", packages.Reverse())}");
            }
            else if (packages.Count == 0 && couriers.Count > 0)
            {
                Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
            }
        }
    }
}
//09:11:01 22.06.2024