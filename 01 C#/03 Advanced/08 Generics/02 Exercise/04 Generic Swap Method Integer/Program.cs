namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>(n);

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SwapElements(list, indexes);
        }

        static void SwapElements<T>(List<T> list, int[] indexes)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

            foreach (T t in list)
            {
                Console.WriteLine($"{typeof(T)}: {t}");
              //Console.WriteLine($"{t.GetType()}: {t}");
            }
        }
    }
}