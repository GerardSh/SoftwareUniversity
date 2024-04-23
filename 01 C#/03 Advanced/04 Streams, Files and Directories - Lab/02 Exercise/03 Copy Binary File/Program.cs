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




//2
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
            using var fileWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] buffer = new byte[4096];

            int currentBytesRead = 0;

            while ((currentBytesRead = fileReader.Read(buffer)) != 0)
            {
                if (currentBytesRead < buffer.Length)
                {
                    fileWriter.Write(buffer, 0, currentBytesRead);
                }
                else
                {
                    fileWriter.Write(buffer);
                }
            }
        }
    }
}