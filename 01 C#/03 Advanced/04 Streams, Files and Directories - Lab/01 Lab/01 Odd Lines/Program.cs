namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"temp\01. Odd Lines\Input.txt";
            string outputFilePath = @"temp\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            int rowCounter = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (rowCounter++ % 2 == 1)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}