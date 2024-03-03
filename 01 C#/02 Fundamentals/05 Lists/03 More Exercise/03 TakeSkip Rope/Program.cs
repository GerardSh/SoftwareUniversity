string input = Console.ReadLine();

List<int> numbers = new List<int>(input.Length);

for (int i = 0; i < input.Length; i++)
{
    if (char.IsDigit(input[i]))
    {
        numbers.Add(int.Parse(input[i].ToString()));
        input = input.Remove(i--, 1);
    }
}

List<int> take = new List<int>(numbers.Count / 2);
List<int> skip = new List<int>(numbers.Count / 2);

for (int i = 0; i < numbers.Count; i++)
{
    if (i % 2 == 0)
    {
        take.Add(numbers[i]);
    }
    else
    {
        skip.Add(numbers[i]);
    }
}

string result = "";

int countListElements = 0;
int countTakenProgress = 0;

bool isFirst = true;

for (int i = 0; i < input.Length;)
{
    if (countListElements == take.Count)
    {
        break;
    }

    if (isFirst)
    {
        if (countTakenProgress == take[countListElements])
        {
            isFirst = false;
            countTakenProgress = 0;
            continue;
        }
        else
        {
            result += input[i];
            countTakenProgress++;

            i++;
        }
    }
    else
    {
        i += skip[countListElements];
        isFirst = true;
        countListElements++;
    }
}

Console.WriteLine(result);




//2
string input = Console.ReadLine();

List<int> numbers = new List<int>(input.Length);

for (int i = 0; i < input.Length; i++)
{
    if (char.IsDigit(input[i]))
    {
        numbers.Add(int.Parse(input[i].ToString()));
        input = input.Remove(i--, 1);
    }
}

List<int> take = new List<int>(numbers.Count / 2);
List<int> skip = new List<int>(numbers.Count / 2);

for (int i = 0; i < numbers.Count; i++)
{
    if (i % 2 == 0)
    {
        take.Add(numbers[i]);
    }
    else
    {
        skip.Add(numbers[i]);
    }
}

string result = "";

int iterationProgress = 0;

for (int i = 0; i < take.Count; i++)
{
    for (int j = 0; j < take[i] && iterationProgress < input.Length; j++)
    {
        result += input[iterationProgress++];
    }

    iterationProgress += skip[i];
}
Console.WriteLine(result);