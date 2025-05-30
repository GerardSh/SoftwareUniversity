﻿class Program
{
    static void Main()
    {
        long sum = 0;

        var task = Task.Run(() =>
        {
            for (long i = 1; i < 1000000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
        });

        while (true)
        {
            var line = Console.ReadLine();

            if (line == "exit")
            {
                return;
            }
            else if (line == "show")
            {
                Console.WriteLine(sum);
            }
        }
    }
}