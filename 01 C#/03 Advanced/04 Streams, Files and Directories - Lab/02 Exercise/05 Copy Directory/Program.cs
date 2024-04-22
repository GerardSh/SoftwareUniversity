namespace CopyDirectory
{
    using System;
    using System.Text.RegularExpressions;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var files = Directory.GetFiles(inputPath);

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            foreach (var file in files)
            {
                using var fileReader = new FileStream(file, FileMode.Open);

                byte[] buffer = new byte[fileReader.Length];

                //Option1
                var newFilePath = file.Replace(inputPath, outputPath);

                //Option2
                //var fileToCopy = new FileInfo(file);
                //var newFilePath = outputPath + "\\" + fileToCopy.Name;

                //Option3
                //var newFilePath = Regex.Replace(file,inputPath.Replace("\\","\\\\"), outputPath);

                using var fileWriter = new FileStream(newFilePath, FileMode.Create);
                fileWriter.Write(buffer);
            }
        }
    }
}