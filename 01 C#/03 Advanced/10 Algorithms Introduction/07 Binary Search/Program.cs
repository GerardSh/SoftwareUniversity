namespace ConsoleApp
{
    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int midIndex = low + (high - low) / 2;

                if (key > arr[midIndex])
                {
                    low = midIndex + 1;

                }
                else if (key < arr[midIndex])
                {
                    high = midIndex - 1;
                }
                else
                {
                    return midIndex;
                }
            }

            return -1;
        }
    }

    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.IndexOf(numbers, key));
        }
    }
}