List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string text = Console.ReadLine();


for (int i = 0; i < numbers.Count; i++)
{
    int elementSum = 0;

    while (numbers[i] > 0)
    {
        elementSum += numbers[i] % 10;
        numbers[i] /= 10;
    }

    while (elementSum > text.Length)
    {
        elementSum -= text.Length;
    }

    Console.Write(text[elementSum]);

    text = text.Remove(elementSum, 1);
}