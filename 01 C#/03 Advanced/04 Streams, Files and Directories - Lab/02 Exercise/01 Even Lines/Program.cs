namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"temp\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using var reader = new StreamReader(inputFilePath);

            int lineRow = 0;

            string allText = null;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (lineRow++ % 2 == 1)
                {
                    continue;
                }

                line = ReplaceSymbols(line);

                allText += ReverseWords(line) + "\n";
            }

            return allText;
        }
        private static string ReverseWords(string replacedSymbols)
        {
            string[] reversedText = replacedSymbols.Split(' ');

            Array.Reverse(reversedText);

            return string.Join(" ", reversedText);
        }

        private static string ReplaceSymbols(string line)
        {
            line = line.Replace('-', '@');
            line = line.Replace(',', '@');
            line = line.Replace('.', '@');
            line = line.Replace('!', '@');
            line = line.Replace('?', '@');

            return line;
        }
    }
}