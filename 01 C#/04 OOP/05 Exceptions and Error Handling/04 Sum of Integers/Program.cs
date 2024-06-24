namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ");
            int sum = 0;

            foreach (string element in input)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}