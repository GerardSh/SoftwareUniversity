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




//2
string input;

var languagesByStudent = new Dictionary<string, Dictionary<string, int>>();
var languages = new Dictionary<string, int>();

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] elements = input
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    string user = elements[0];

    if (elements[1] == "banned")
    {
        if (languagesByStudent.ContainsKey(user))
        {
            languagesByStudent.Remove(user);
        }

        continue;
    }

    string language = elements[1];
    int scores = int.Parse(elements[2]);

    if (!languagesByStudent.ContainsKey(user))
    {
        languagesByStudent[user] = new Dictionary<string, int>();
    }

    if (!languages.ContainsKey(language))
    {
        languages[language] = 0;
    }

    languages[language]++;

    if (!languagesByStudent[user].ContainsKey(language))
    {
        languagesByStudent[user][language] = 0;
    }

    if (languagesByStudent[user][language] < scores)
    {
        languagesByStudent[user][language] = scores;
    }
}

Console.WriteLine("Results:");

foreach (var kvp in languagesByStudent.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{kvp.Key} | {kvp.Value.Values.Sum()}");
}

Console.WriteLine("Submissions:");

foreach (var kvp in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}