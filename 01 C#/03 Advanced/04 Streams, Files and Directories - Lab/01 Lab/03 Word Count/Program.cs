namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"temp\words.txt";
            string textPath = @"temp\text.txt";
            string outputPath = @"temp\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(wordsFilePath);
            using StreamReader sr2 = new StreamReader(textFilePath);

            HashSet<string> words = new HashSet<string>();

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split();
                
                foreach (string word in line)
                {
                    words.Add(word);
                }
            }

            var countByWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                countByWords[word] = 0;
            }

            while (!sr2.EndOfStream)
            {
                string[] line = sr2.ReadLine().Split(new char[] { ' ', ',', '!', '?', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in line)
                {
                  foreach (var kvp in countByWords)
                    {
                        if (kvp.Key.ToLower() == word.ToLower())
                        {
                            countByWords[kvp.Key]++;
                            break;
                        }
                    }
                }
            }

            using StreamWriter sw = new StreamWriter(outputFilePath);

            foreach (var kvp in countByWords.OrderByDescending(x=>x.Value))
            {
                sw.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}