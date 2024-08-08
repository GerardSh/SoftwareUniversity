using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            Match match = Regex.Match(input, @"(\*|@)([A-Z][a-z]{2,})\1: \[([(A-Za-z)])\]\|\[([A-Za-z])\]\|\[([(A-Za-z)])\]\|$");

            if (!match.Success)
            {
                Console.WriteLine("Valid message not found!");

                continue;
            }

            Console.WriteLine($"{match.Groups[2].Value}: {(int)Char.Parse(match.Groups[3].Value)} {(int)Char.Parse(match.Groups[4].Value)} {(int)Char.Parse(match.Groups[5].Value)}");
        }
    }
}

//Created on: 08 / 08 / 2024 09:38:57