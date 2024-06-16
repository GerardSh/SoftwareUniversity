public class Program
{
    public static void Main()
    {
        try
        {
            double number = double.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }

            number = Math.Sqrt(number);

            Console.WriteLine(number);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }
}