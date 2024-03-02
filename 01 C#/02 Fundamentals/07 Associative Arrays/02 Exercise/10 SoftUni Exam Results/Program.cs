using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Test
    {
        static void Main()
        {
            var countByLanguages = new Dictionary<string, int>();
            var scoresByStudents = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] commands = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];

                if (commands.Length > 2)
                {
                    string language = commands[1];
                    int scores = int.Parse(commands[2]);

                    if (!scoresByStudents.ContainsKey(name))
                    {
                        scoresByStudents.Add(name, 0);
                    }

                    if (scoresByStudents[name] < scores)
                    {
                        scoresByStudents[name] = scores;
                    }

                    if (!countByLanguages.ContainsKey(language))
                    {
                        countByLanguages[language] = 0;
                    }

                    countByLanguages[language]++;
                }
                else
                {
                    scoresByStudents.Remove(name);
                }
            }

            var sortedStudents = scoresByStudents.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            var sortedLanguages = countByLanguages.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Submissions:");

            foreach (var kvp in sortedLanguages)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}