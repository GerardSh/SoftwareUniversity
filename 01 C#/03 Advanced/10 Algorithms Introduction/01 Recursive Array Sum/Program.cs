namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int result = GetArraySum(0, Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(result);
        }

        static int GetArraySum(int index, params int[] numbers)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + GetArraySum(index + 1, numbers);
        }
    }
}