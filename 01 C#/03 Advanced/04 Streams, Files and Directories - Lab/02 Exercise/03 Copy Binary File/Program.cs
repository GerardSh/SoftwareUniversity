using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"temp\copyMe.png";
            string outputPath = @"temp\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using var fileReader = new FileStream(inputFilePath, FileMode.Open);

            byte[] buffer = new byte[fileReader.Length];

            fileReader.Read(buffer);

            using var fileWriter = new FileStream(outputFilePath, FileMode.Create);

            fileWriter.Write(buffer);
        }
    }
}