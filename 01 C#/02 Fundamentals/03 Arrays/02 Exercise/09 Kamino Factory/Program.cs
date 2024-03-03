int sequenceLength = int.Parse(Console.ReadLine());
string input;
int maxSequenceCount = 0;
string bestSequence = "";
int sampleCount = 0;
int bestSampleCount = 0;

int bestSequenceSum = 0;
int bestSequenceIndex = int.MaxValue;

while ((input = Console.ReadLine()) != "Clone them!")
{
    sampleCount++;
    int[] dnaArr = input
        .Split("!", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int sequence = 0;
    int sequenceIndex = 0;
    int sumSampleNumbers = 0;

    for (int j = 0; j < dnaArr.Length; j++)
    {
        sumSampleNumbers += dnaArr[j];
    }

    for (int i = 0; i < dnaArr.Length; i++)
    {
        if (dnaArr[i] == 1)
        {
            sequence++;

            if (sequence == 1)
            {
                sequenceIndex = i;
            }
        }
        else
        {
            sequence = 0;
        }

        if (sequence > maxSequenceCount
            || sequence == maxSequenceCount && sequenceIndex < bestSequenceIndex
            || sequence == maxSequenceCount && sequenceIndex == bestSequenceIndex && sumSampleNumbers > bestSequenceSum)
        {
            maxSequenceCount = sequence;
            bestSequenceIndex = sequenceIndex;
            bestSequence = string.Join(" ", dnaArr);
            bestSequenceSum = sumSampleNumbers;
            bestSampleCount = sampleCount;
        }

    }
}

Console.WriteLine($"Best DNA sample {bestSampleCount} with sum: {bestSequenceSum}.");
Console.WriteLine(bestSequence);




//2
int size = int.Parse(Console.ReadLine());

int bestSequenceCountAll = 0;
int bestSumAll = 0;
int bestIndexAll = int.MaxValue;
int arrCount = 0;
int bestArrCount = 0;
int bestIndex = 0;

int[] bestArr = new int[size];

string input;

while ((input = Console.ReadLine()) != "Clone them!")
{
    int[] currentArr = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    arrCount++;

    int sequenceCount = 0;
    int bestSequenceCountInArr = 0;
    int index = 0;
    int sumCurrentArr = 0;

    for (int i = 0; i < currentArr.Length; i++)
    {
        if (currentArr[i] == 1)
        {
            sequenceCount++;
            sumCurrentArr++;
        }
        else
        {
            sequenceCount = 0;
        }

        if (sequenceCount > bestSequenceCountInArr)
        {
            bestSequenceCountInArr = sequenceCount;
            index = i - bestSequenceCountInArr + 1;
        }
    }

    if (bestSequenceCountInArr > bestSequenceCountAll)
    {
        bestSequenceCountAll = bestSequenceCountInArr;
        bestIndexAll = index;
        bestArr = currentArr;
        bestSumAll = sumCurrentArr;
        bestArrCount = arrCount;
    }

    else if (bestSequenceCountInArr == bestSequenceCountAll && index < bestIndexAll)
    {
        bestIndexAll = index;
        bestArr = currentArr;
        bestSumAll = sumCurrentArr;
        bestArrCount = arrCount;
    }

    else if (bestSequenceCountInArr == bestSequenceCountAll && index == bestIndexAll && sumCurrentArr > bestSumAll)
    {
        bestArr = currentArr;
        bestSumAll = sumCurrentArr;
        bestArrCount = arrCount;
    }
}

Console.WriteLine($"Best DNA sample {bestArrCount} with sum: {bestSumAll}.");
Console.WriteLine(string.Join(" ", bestArr));

//test variant with link
string input = "";
string inputAll = "";

//taking all the input in one variable
while ((input = Console.ReadLine()) != "Clone them!")
{
    inputAll += input + "*";
}

//Removing marks with for cycle
string removeMarks = "";
for (int i = 0; i < inputAll.Length; i++)
{
    if (inputAll[i] == '!' && inputAll[i + 1] == '!'
        || inputAll[i] == 's'
        || removeMarks.Length == 0 && inputAll[i] == '!')
    {
        continue;
    }
    else
    {
        if (removeMarks.Length > 0
            && removeMarks[removeMarks.Length - 1] == '!'
            && inputAll[i] == '!')
        {
            continue;
        }

        removeMarks += inputAll[i];
    }
}
inputAll = removeMarks;

//creating the array;
string[] test = inputAll.Split('*', StringSplitOptions.RemoveEmptyEntries);

// variant 2 with for's
string input = "";
string inputAll = "";
int countElements = 0;

//taking all the input in one string.
while ((input = Console.ReadLine()) != "Clone them!")
{
    inputAll += input + "*";
    countElements++;
}

// making an array with for cycles.
string[] test = new string[countElements];
int arrayIndex = 0;
string oneElement = "";

for (int i = 0; i < inputAll.Length; i++)
{
    if (inputAll[i] != '*')
    {
        oneElement += inputAll[i];
    }
    else
    {
        test[arrayIndex] = oneElement;
        oneElement = "";
        arrayIndex++;
    }
}
//removing all the extra '!' symbols from the array elements with for cycles.
for (int i = 0; i < test.Length; i++)
{
    string markRemoved = "";
    for (int j = 0; j < test[i].Length; j++)
    {
        if (test[i][j] != '!')
        {
            markRemoved += test[i][j];
        }
        else if (test[i][j] == '!')
        {
            if (test[i][j + 1] == '!')
            {
                continue;
            }
            else
            {
                markRemoved += test[i][j];
            }
        }
    }
    test[i] = markRemoved;
}