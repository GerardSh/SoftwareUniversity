namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            string valueToCompare = Console.ReadLine();

            Console.WriteLine(CompareElements(list, valueToCompare));
        }

        static int CompareElements<T>(List<T> list, T valueToCompare)
            where T : IComparable<T>
        {
            return list.Count(x => x.CompareTo(valueToCompare) > 0);
        }
    }
}