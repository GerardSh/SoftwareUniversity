using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string input;

        while ((input = Console.ReadLine()) != "Easter")
        {
            string[] elements = input.Split();

            string command = elements[0];

            if (command == "Replace")
            {
                char currentChar = char.Parse(elements[1]);
                char newChar = char.Parse(elements[2]);

                text = text.Replace(currentChar, newChar);
            }
            else if (command == "Remove")
            {
                string substring = elements[1];

                text = text.Replace(substring, "");
            }
            else if (command == "Includes")
            {
                string substring = elements[1];

                Console.WriteLine(text.Contains(substring));

                continue;
            }
            else if (command == "Change")
            {
                string casing = elements[1];

                text = text.ToLower();

                if (casing == "Upper")
                {
                    text = text.ToUpper();
                }
            }
            else if (command == "Reverse")
            {
                int startIndex = int.Parse(elements[1]);
                int endIndex = int.Parse(elements[2]);

                if (startIndex < 0 || endIndex < startIndex || endIndex >= text.Length)
                {
                    continue;
                }

                string substring = text.Substring(startIndex, endIndex - startIndex + 1);

                Console.WriteLine(string.Concat(substring.Reverse()));

                continue;
            }

            Console.WriteLine(text);
        }
    }
}

//Created on: 08 / 08 / 2024 09:16:00