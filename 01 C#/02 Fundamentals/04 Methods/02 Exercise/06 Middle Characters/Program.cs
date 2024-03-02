string input = Console.ReadLine();

MiddleCharacters(input);

static void MiddleCharacters(string input)
{
    for (int i = 0; i <= input.Length / 2; i++)
    {
        bool evenLenght = input.Length % 2 == 0;
        int indexAtHalfLength = input.Length / 2;

        if (evenLenght)
        {
            if (i == indexAtHalfLength - 1)
            {
                Console.Write(input[i]);
            }
        }

        if (i == indexAtHalfLength)
        {
            Console.Write(input[i]);
        }
    }
}