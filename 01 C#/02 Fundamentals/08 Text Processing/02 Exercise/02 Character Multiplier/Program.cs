string[] input = Console.ReadLine().Split(" ");

int charsSum = CharacterMultiplier(input[0], input[1]);

Console.WriteLine(charsSum);

int CharacterMultiplier(string textOne, string textTwo)
{
    int sum = 0;

    for (int i = 0; i < Math.Max(textOne.Length, textTwo.Length); i++)
    {
        if (textOne.Length <= i)
        {
            sum += textTwo[i];
        }
        else if (textTwo.Length <= i)
        {
            sum += textOne[i];
        }
        else
        {
            sum += textOne[i] * textTwo[i];
        }
    }

    return sum;
}