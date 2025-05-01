class Program
{
    static void Main()
    {
        int start = 0;
        int end = 100;

        Thread evens = new Thread(() => PrintEvenNumbers(start, end));

        evens.Start();
        evens.Join();

        Console.WriteLine("Thread finished work");   
    }

    static void PrintEvenNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0) Console.WriteLine(i);
        }
    }
}