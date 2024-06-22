namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            var words = new Dictionary<string, int>()
            {
                {"pear",0 },
                {"flour",0 },
                {"pork", 0 },
                {"olive", 0 }
            };

            var wordsString = "pear flour pork olive";

            var matchingLetters = new HashSet<char>();

            while (consonants.Count > 0)
            {
                char consontant = consonants.Pop();
                char vowel = vowels.Dequeue();
                vowels.Enqueue(vowel);

                if (wordsString.Contains(consontant))
                {
                    matchingLetters.Add(consontant);
                }

                if (wordsString.Contains(vowel))
                {
                    matchingLetters.Add(vowel);
                }
            }

            foreach (var kvp in words)
            {
                string word = kvp.Key;
                bool wordFound = true;

                foreach (var letter in word)
                {
                    if (!matchingLetters.Contains(letter))
                    {
                        wordFound = false;
                        break;
                    }
                }

                if (wordFound)
                {
                    words[kvp.Key]++;
                }
            }

            int wordsFound = words.Sum(x => x.Value);

            Console.WriteLine($"Words found: {wordsFound}");

            foreach (var kvp in words)
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}