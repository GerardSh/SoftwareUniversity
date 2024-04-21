namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"temp\TestFolder";
            string outputPath = @"temp\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            int sizeInBytes = 0;

            var subDirectories = Directory.GetDirectories(@"temp\TestFolder");
            var filesInDirectory = Directory.GetFiles(@"temp\TestFolder");

            sizeInBytes += GetFoldersSize(filesInDirectory);

            foreach (var directory in subDirectories)
            {
                filesInDirectory = Directory.GetFiles(directory);
                sizeInBytes += GetFoldersSize(filesInDirectory);
            }

            double sizeInKiloBytes = (sizeInBytes / 1024.0);

            using var writer = new StreamWriter(outputFilePath);

            writer.Write(sizeInKiloBytes + " KB");
        
            static int GetFoldersSize(string[] files)
            {
                int sizeInBytes = 0;

                foreach (var file in files)
                {
                    using var reader = new FileStream(file, FileMode.Open);
                    sizeInBytes += (int)reader.Length;
                }

                return sizeInBytes;
            }
        }
    }
}
