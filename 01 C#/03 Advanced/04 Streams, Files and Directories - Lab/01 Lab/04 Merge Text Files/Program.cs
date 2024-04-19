namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"temp\input1.txt";
            var secondInputFilePath = @"temp\input2.txt";
            var outputFilePath = @"temp\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using var readerOne = new StreamReader(firstInputFilePath);
            using var readerTwo = new StreamReader(secondInputFilePath);
            using var sw = new StreamWriter(outputFilePath);

            List<string> inputOne = new List<string>();
            List<string> inputTwo = new List<string>();

            while (!readerOne.EndOfStream)
            {
                string line = readerOne.ReadLine();
                inputOne.Add(line);
            }

            while (!readerTwo.EndOfStream)
            {
                string line = readerTwo.ReadLine();
                inputTwo.Add(line);
            }

            //Option 1
            int smallerListCount = Math.Min(inputOne.Count, inputTwo.Count);
            int biggestListCount = Math.Max(inputOne.Count, inputTwo.Count);

            for (int i = 0; i < smallerListCount; i++)
            {
                sw.WriteLine(inputOne[i]);
                sw.WriteLine(inputTwo[i]);
            }

            if (smallerListCount == biggestListCount)
            {
                return;
            }

            if (smallerListCount == inputOne.Count)
            {
                for (int i = smallerListCount; i < biggestListCount; i++)
                {
                    sw.WriteLine(inputTwo[i]);
                }
            }
            else
            {
                for (int i = smallerListCount; i < biggestListCount; i++)
                {
                    sw.WriteLine(inputOne[i]);
                }
            }

            //Option 2
            int lineCount = 0;

            while (inputOne.Count > lineCount || inputTwo.Count > lineCount)
            {
                if (inputOne.Count > lineCount)
                {
                    sw.WriteLine(inputOne[lineCount]);
                }

                if (inputTwo.Count > lineCount)
                {
                    sw.WriteLine(inputTwo[lineCount]);
                }

                lineCount++;
            }
        }
    }
}




//2
namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"temp\input1.txt";
            var secondInputFilePath = @"temp\input2.txt";
            var outputFilePath = @"temp\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using var readerOne = new StreamReader(firstInputFilePath);
            using var readerTwo = new StreamReader(secondInputFilePath);
            using var sw = new StreamWriter(outputFilePath);

            List<string> inputOne = new List<string>();
            List<string> inputTwo = new List<string>();

            while (!readerOne.EndOfStream)
            {
                string line = readerOne.ReadLine();
                inputOne.Add(line);
            }

            while (!readerTwo.EndOfStream)
            {
                string line = readerTwo.ReadLine();
                inputTwo.Add(line);
            }

           
        }
    }
}