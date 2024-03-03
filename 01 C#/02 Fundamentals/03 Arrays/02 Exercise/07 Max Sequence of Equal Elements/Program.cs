int[] arr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string sequence = "";
int sequenceCount = 0;
int longestSequenceCount = 0;
string longestSequence = "";
bool checkEqual = true;


for (int i = 0; i < arr.Length - 1; i++)
{
    if (arr[i] == arr[i + 1])
    {
        if (sequenceCount == 0)
        {
            sequence += arr[i] + " " + arr[i + 1] + " ";
            sequenceCount++;

            if (sequenceCount > longestSequenceCount)
            {
                longestSequenceCount = sequenceCount;
                longestSequence = sequence;
            }
        }
        else if (sequenceCount > 0)
        {
            sequence += arr[i + 1] + " ";
            sequenceCount++;

            if (i == arr.Length - 2)
            {
                if (sequenceCount > longestSequenceCount)
                {
                    longestSequenceCount = sequenceCount;
                    longestSequence = sequence;
                }
            }
        }
    }
    else
    {
        if (sequenceCount > longestSequenceCount)
        {
            longestSequenceCount = sequenceCount;
            longestSequence = sequence;
        }

        sequence = "";
        sequenceCount = 0;
    }



    if (arr[i] != arr[i + 1])
    {
        checkEqual = false;
    }
}

if (checkEqual)
{
    Console.WriteLine(sequence);
}
else if (longestSequenceCount == 0)
{
    Console.WriteLine(arr[0]);
}
else
{
    Console.WriteLine(longestSequence);
}




//2
int[] arr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string maxSequence = "";
int maxSequenceCount = 0;

for (int i = 0; i < arr.Length; i++)
{
    string currentSequence = arr[i].ToString() + " ";
    int currentSequenceCount = 0;

    for (int j = i + 1; j < arr.Length; j++)
    {
        if (arr[i] == arr[j])
        {
            currentSequence += arr[j] + " ";
            currentSequenceCount++;
        }
        else
        {
            break;
        }
    }

    if (currentSequenceCount > maxSequenceCount)
    {
        maxSequence = currentSequence;
        maxSequenceCount = currentSequenceCount;
    }
}

if (maxSequenceCount > 0)
{
    Console.WriteLine(maxSequence);
}
else
{
    Console.WriteLine(arr[0]);
}




//3
int[] arr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int maxSequenceSize = 0;
int sequenceCounter = 1;
int numberInMaxSequence = 0;

for (int i = 0; i < arr.Length - 1; i++)
{
    if (arr[i] == arr[i + 1])
    {
        sequenceCounter++;
    }
    else
    {
        sequenceCounter = 1;
    }

    if (sequenceCounter > maxSequenceSize)
    {
        maxSequenceSize = sequenceCounter;
        numberInMaxSequence = arr[i];
    }
}

for (int i = 0; i < maxSequenceSize; i++)
{
    Console.Write(numberInMaxSequence + " ");
}




//4
var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var bestSequence = 0;
var bestNumber = 0;


for (int i = 0; i < numbers.Length; i++)
{
    var sequence = 1;

    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] == numbers[j])
        {
            sequence++;
        }
        else
        {
            break;
        }
    }
    if (sequence > bestSequence)
    {
        bestSequence = sequence;
        bestNumber = numbers[i];
    }
}

for (int i = 0; i < bestSequence; i++)
{
    Console.Write(bestNumber + " ");
}