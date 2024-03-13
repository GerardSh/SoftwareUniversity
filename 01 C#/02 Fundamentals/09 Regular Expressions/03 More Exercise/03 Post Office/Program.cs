using System.Text.RegularExpressions;

string[] parts = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> words = new Dictionary<string, int>();

List<char> chars = Regex.Match(parts[0], @"([#$%*&]+)([A-Z]+)\1").Groups[2].Value.ToList();

foreach (char c in chars)
{
    words.Add(c.ToString(), 0);
}

MatchCollection codeWithWordLength = Regex.Matches(parts[1], @"(?<code>\d{2}):(?<length>\d{2})");

foreach (Match code in codeWithWordLength)
{
    string capitalLetter = ((char)int.Parse(code.Groups["code"].Value)).ToString();
    int wordLength = int.Parse(code.Groups["length"].Value);

    if (words.ContainsKey(capitalLetter))
    {
        words[capitalLetter] = wordLength;
    }
}

string[] thirdPartWords = parts[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var word in words)
{
    string capitalLetter = word.Key;
    int charactersLength = word.Value;

    foreach (var word2 in thirdPartWords)
    {
        string capitalLetter2 = word2[0].ToString();
        int charactersLength2 = word2.Length - 1;

        if (capitalLetter == capitalLetter2 && charactersLength == charactersLength2)
        {
            Console.WriteLine(word2);
        }
    }
}




//2
using System.Text.RegularExpressions;

string[] array = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries);

string partOne = array[0];
string partTwo = array[1];
string partThree = array[2];

string capitalLetters = Regex.Match(partOne, @"([#$%*&])([A-Z]+)\1").Groups[2].Value;

MatchCollection symbolsAndLength = Regex.Matches(partTwo, @"(\d{2}):(\d{2})");

for (int i = 0; i < capitalLetters.Length; i++)
{
    int capitalSymbol = capitalLetters[i];
    int wordLength = 0;

    foreach (Match match in symbolsAndLength)
    {
        if (match.Groups[1].Value == capitalSymbol.ToString())
        {
            wordLength = int.Parse(match.Groups[2].Value);
            break;
        }
    }

    foreach (string word in partThree.Split(" ", StringSplitOptions.RemoveEmptyEntries))
    {
        if (word[0] == capitalSymbol && word.Length == wordLength + 1)
        {
            Console.WriteLine(word);
        }
    }
}




//3
using System.Text.RegularExpressions;

string[] array = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries);

string partOne = array[0];
string partTwo = array[1];
string partThree = array[2];

string capitalLetters = Regex.Match(partOne, @"([#$%*&])([A-Z]+)\1").Groups[2].Value;

MatchCollection symbolsAndLength = Regex.Matches(partTwo, @"(\d{2}):(\d{2})");

foreach (char c in capitalLetters)
{
    int capitalSymbol = c;
    int wordLength = int.Parse(Regex.Match(partTwo, $@"{capitalSymbol}:(\d{{2}})").Groups[1].Value);

    string wordToPrint = Regex.Match(partThree, $@"(?<=\s|^){(char)capitalSymbol}[^\s]{{{wordLength}}}(?=\s|$)").Value;

    Console.WriteLine(wordToPrint);
}