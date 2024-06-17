public class Program
{
    static List<int> numbers = new List<int>();

    public static void Main()
    {
        int start = 1;
        int end = 100;

        while (numbers.Count < 10)
        {
            try
            {
                numbers.Add(ReadNumber(start, end));
                start = numbers[numbers.Count - 1];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Number!");
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
    public static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number <= start || number >= end)
        {
            throw new ArgumentException($"Your number is not in range {start} - {end}!");
        }

        return number;
    }
}