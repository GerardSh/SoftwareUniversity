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




//2
namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Func<int, int, int> comparator = (x, y) => (x % 2 != 0 && y % 2 == 0 ? 1 :
                                                        x % 2 == 0 && y % 2 != 0 ? -1 :
                                                        x.CompareTo(y));

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            //Option 1
            numbers.Sort((x, y) => comparator(x, y));

            //Option 2
            //numbers.Sort(new Comparison<int>(comparator));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}