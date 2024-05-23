using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ", array));
        }

        public static int Part(int[] array, int low, int high, int pivot)
        {
            while (low <= high)
            {
                while (array[low] < pivot)
                {
                    low++;
                }

                while (array[high] > pivot)
                {
                    high--;
                }

                if (low <= high)
                {
                    int temp = array[low];
                    array[low] = array[high];
                    array[high] = temp;
                    low++;
                    high--;
                }
            }

            return low;
        }

        public static void QuickSort(int[] array, int lo, int high)
        {
            if (lo >= high) return;

            int pivot = array[(lo + high) / 2];
            int index = Part(array, lo, high, pivot);

            QuickSort(array, lo, index - 1);

            QuickSort(array, index, high);
        }
    }
}