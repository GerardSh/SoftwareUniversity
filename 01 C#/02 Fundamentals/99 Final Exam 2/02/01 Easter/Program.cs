class Program
{
    public static void Main()
    {
        string text = Console.ReadLine();

        string input;

        while ((input = Console.ReadLine()) != "Easter")
        {
            var elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = elements[0];

            switch (command)
            {
                case "Replace":
                    char currentChar = elements[1][0];
                    char newChar = elements[2][0];

                    text = text.Replace(currentChar, newChar);

                    Console.WriteLine(text);
                    break;
                case "Remove":
                    {
                        string substring = elements[1];

                        text = text.Replace(substring, "");

                        Console.WriteLine(text);
                        break;
                    }
                case "Includes":
                    {
                        string substring = elements[1];

                        if (text.Contains(substring))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    }
                case "Change":
                    string casing = elements[1];

                    text = text.ToLower();

                    if (casing == "Upper")
                    {
                        text = text.ToUpper();
                    }

                    Console.WriteLine(text);
                    break;

                case "Reverse":
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);
                    int count = endIndex - startIndex + 1;

                    if (startIndex < 0 || startIndex > endIndex || endIndex > text.Length - 1)
                    {
                        continue;
                    }

                    string textToReverse = text.Substring(startIndex, count);

                    Console.WriteLine(string.Concat(textToReverse.Reverse()));
                    break;
            }
        }
    }
}

// Created on: 05 / 12 / 2024 09:55:03