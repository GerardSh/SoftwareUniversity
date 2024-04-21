namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"temp\example.png";
            string joinedFilePath = @"temp\example-joined.png";
            string partOnePath = @"temp\part-1.bin";
            string partTwoPath = @"temp\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using var fileReader = new FileStream(sourceFilePath, FileMode.Open);

            int fileParts = 2;

            long partSize = (long)Math.Ceiling(fileReader.Length / (double)fileParts);

            for (int i = 1; i <= fileParts; i++)
            {
                byte[] buffer = new byte[partSize];

                if (fileReader.Length % 2 == 1 && i == fileParts)
                {
                    buffer = new byte[partSize - fileParts + 1];
                }

                fileReader.Read(buffer);

                using var writer = new FileStream($@"temp\part-{i}.bin", FileMode.Create);

                writer.Write(buffer);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            var readers = new FileStream[] { new FileStream(partOneFilePath, FileMode.Open), new FileStream(partTwoFilePath, FileMode.Open) };

            for (int i = 0; i < 2; i++)
            {
                using var writer = new FileStream(joinedFilePath, FileMode.Append);

                byte[] buffer = new byte[readers[i].Length];

                readers[i].Read(buffer);

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}




//2
namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"temp\example.png";
            string joinedFilePath = @"temp\example-joined.png";
            string partOnePath = @"temp\part-1.bin";
            string partTwoPath = @"temp\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(sourceFilePath, partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using var fileReader = new FileStream(sourceFilePath, FileMode.Open);

            int fileParts = 2;

            byte[] buffer = new byte[fileReader.Length];

            fileReader.Read(buffer);

            using var fileWriter = new FileStream(partOneFilePath, FileMode.Create);
            using var fileWriterTwo = new FileStream(partTwoFilePath, FileMode.Create);

            if (buffer.Length % 2 == 0)
            {
                fileWriter.Write(buffer, 0, buffer.Length / fileParts);
                fileWriterTwo.Write(buffer, buffer.Length / fileParts, buffer.Length / fileParts);
            }
            else
            {
                fileWriter.Write(buffer, 0, buffer.Length / fileParts + 1);
                fileWriterTwo.Write(buffer, buffer.Length / fileParts + 1, buffer.Length / fileParts);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using var fileReaderOne = new FileStream(partOneFilePath, FileMode.Open);
            using var fileReaderTwo = new FileStream(partTwoFilePath, FileMode.Open);

            byte[] buffer = new byte[fileReaderOne.Length + fileReaderTwo.Length];

            fileReaderOne.Read(buffer, 0, (int)fileReaderOne.Length);
            fileReaderTwo.Read(buffer, (int)fileReaderOne.Length, (int)fileReaderTwo.Length);
        }
    }
}