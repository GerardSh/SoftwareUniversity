﻿namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());

                Console.WriteLine(box);
            }
        }
    }
}