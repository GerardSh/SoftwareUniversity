string input = Console.ReadLine();

int vowelsCount = VowelCount(input);

Console.WriteLine(vowelsCount);

static int VowelCount(string input)
{
    int count = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u' ||
         input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
        {
            count++;
        }
    }

    return count;

}