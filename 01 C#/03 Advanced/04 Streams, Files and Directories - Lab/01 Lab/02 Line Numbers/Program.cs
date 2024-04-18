namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"temp\LineNumbers\Input.txt";
            string outputPath = @"temp\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using var sr = new StreamReader(inputFilePath);
            using var sw = new StreamWriter(outputFilePath);

            int rowCount = 1;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                sw.WriteLine($" {rowCount++}.{line}");
            }
        }
    }
}
