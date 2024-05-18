namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var lake = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}