namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionCount = 0;

            while (exceptionCount < 3)
            {
                string[] elements = Console.ReadLine().Split();

                string command = elements[0];

                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(elements[1]);
                        int element = int.Parse(elements[2]);

                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(elements[1]);
                        int endIndex = int.Parse(elements[2]);

                        List<int> result = new List<int>();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            result.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", result));
                    }
                    else
                    {
                        int index = int.Parse(elements[1]);

                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}