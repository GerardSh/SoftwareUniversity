namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            long result = GetFactorial(int.Parse(Console.ReadLine()));

            Console.WriteLine(result);
        }

        static long GetFactorial(int number)
        {
            if (number == 1)
            {
                return number;
            }

            return number * GetFactorial(number - 1);
        }
    }
}