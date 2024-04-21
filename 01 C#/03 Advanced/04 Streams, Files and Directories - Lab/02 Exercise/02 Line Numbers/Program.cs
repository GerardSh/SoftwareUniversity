namespace LineNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"temp\text.txt";
            string outputPath = @"temp\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var textLines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < textLines.Length; i++)
            {
                int punctuationMarks = Regex.Matches(textLines[i], @"[.,!?\-']").Count();
                int letters = Regex.Matches(textLines[i], @"[a-zA-Z]").Count();

                textLines[i] = $"Line {i + 1} {textLines[i]}({letters})({punctuationMarks})";
            }

            File.WriteAllLines(outputFilePath, textLines);
        }
    }
}
