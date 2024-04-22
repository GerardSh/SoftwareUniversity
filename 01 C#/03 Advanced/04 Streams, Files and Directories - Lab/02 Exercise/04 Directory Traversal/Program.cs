namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"temp\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var currentDirectory = new DirectoryInfo(inputFolderPath);

            var files = currentDirectory.GetFiles();
            var filesByExtension = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                if (!filesByExtension.ContainsKey(file.Extension))
                {
                    filesByExtension[file.Extension] = new Dictionary<string, long>();
                }

                filesByExtension[file.Extension][file.Name] = file.Length;
            }

            filesByExtension = filesByExtension
                .OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string filesInDirectory = null;

            foreach (var kvp in filesByExtension)
            {
                filesInDirectory += kvp.Key + "\n";

                foreach (var kvpIneer in kvp.Value.OrderBy(x => x.Value))
                {
                    filesInDirectory += $"--{kvpIneer.Key} - {kvpIneer.Value / 1024.0}kb\n";
                }
            }

            var subDirectories = Directory.GetDirectories(currentDirectory.FullName);

            foreach (var directory in subDirectories)
            {
                filesInDirectory += $"\n{directory}\n" + TraverseDirectory(directory);
            }

            return filesInDirectory;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            using var writer = new StreamWriter(reportFileName);

            writer.Write(textContent);
        }
    }
}