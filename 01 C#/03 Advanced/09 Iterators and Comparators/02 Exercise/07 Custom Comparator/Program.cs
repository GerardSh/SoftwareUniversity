namespace ConsoleApp
{
    public class Comparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            return x.CompareTo(y);
        }
    }

    public class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numbers.Sort(new Comparator());

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}