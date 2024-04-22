namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string inputFile = @"temp\copyMe.png";
            string zipArchiveFile = @"temp\archive.zip";
            string extractedFile = @"temp\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            var tempDirectory = Directory.CreateDirectory($"{Path.GetDirectoryName(inputFilePath)}\\" + Path.GetFileNameWithoutExtension(zipArchiveFilePath));

            File.Copy(inputFilePath, Path.Combine(tempDirectory.FullName, $"file{Path.GetExtension(inputFilePath)}"), true);

            ZipFile.CreateFromDirectory(tempDirectory.FullName, tempDirectory.FullName + ".zip");

            Directory.Delete(tempDirectory.FullName, true);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            ZipFile.ExtractToDirectory(zipArchiveFilePath, Path.GetDirectoryName(outputFilePath));

            var extension = Path.GetExtension(outputFilePath);

            File.Move(Path.GetDirectoryName(outputFilePath) + $"\\file{extension}", outputFilePath);
        }
    }
}
