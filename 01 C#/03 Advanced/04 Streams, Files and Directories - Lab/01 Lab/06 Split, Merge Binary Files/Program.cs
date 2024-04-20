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

        public static void MergeBinaryFiles(string sourceFilePath, string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using var fileReaderOne = new FileStream(partOneFilePath, FileMode.Open);
            using var fileReaderTwo = new FileStream(partTwoFilePath, FileMode.Open);

            byte[] buffer = new byte[fileReaderOne.Length + fileReaderTwo.Length];

            fileReaderOne.Read(buffer, 0, (int)fileReaderOne.Length);
            fileReaderTwo.Read(buffer, (int)fileReaderOne.Length, (int)fileReaderTwo.Length);
        }
    }
}