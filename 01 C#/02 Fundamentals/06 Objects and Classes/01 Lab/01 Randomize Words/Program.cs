string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Random random = new Random();

for (int i = 0; i < words.Length; i++)
{
    int rndNum = random.Next(words.Length);

    string temp = words[rndNum];
    words[rndNum] = words[i];
    words[i] = temp;
}

Console.WriteLine(string.Join("\n", words));