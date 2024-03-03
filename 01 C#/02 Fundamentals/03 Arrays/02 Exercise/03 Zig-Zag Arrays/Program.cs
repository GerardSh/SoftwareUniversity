int n = int.Parse(Console.ReadLine());

var firstArr = new int[n];
var secondArr = new int[n];

bool isFirst = true;

for (int i = 0; i < n; i++)
{
    int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

    if (isFirst)
    {
        firstArr[i] = inputArr[0];
        secondArr[i] = inputArr[1];
        isFirst = false;
    }
    else
    {
        secondArr[i] = inputArr[0];
        firstArr[i] = inputArr[1];
        isFirst = true;
    }
}

Console.WriteLine(string.Join(" ", firstArr));
Console.WriteLine(string.Join(" ", secondArr));




//2
int n = int.Parse(Console.ReadLine());
string digitsA = "";
string digitsB = "";
string arrayA = "";
string arrayB = "";

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    string currentDigit = "";

    for (int j = 0; j < input.Length; j++)
    {
        if (input[j] != ' ')
        {
            currentDigit += input[j];
        }
        else if (input[j] == ' ')
        {
            digitsA = currentDigit;
            currentDigit = "";
        }

        if (j == input.Length - 1)
        {
            digitsB = currentDigit;
        }
    }

    if (i % 2 == 0)
    {
        arrayA += digitsA + " ";
        arrayB += digitsB + " ";
    }
    else
    {
        arrayA += digitsB + " ";
        arrayB += digitsA + " ";
    }
}

Console.WriteLine(arrayA);
Console.WriteLine(arrayB);