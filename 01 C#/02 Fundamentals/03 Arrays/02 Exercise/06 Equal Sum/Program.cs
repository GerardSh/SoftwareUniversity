int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int leftSum = 0;
int rightSum = 0;

bool isFound = false;
int indexPosition = 0;

for (int i = 0; i < arr.Length; i++)
{
    for (int j = i + 1; j < arr.Length; j++)
    {
        rightSum += arr[j];
    }

    for (int k = 0; k < i; k++)
    {
        leftSum += arr[k];
    }

    if (leftSum == rightSum)
    {
        isFound = true;
        indexPosition = i;
    }
    leftSum = 0;
    rightSum = 0;
}

if (isFound)
{
    Console.WriteLine(indexPosition);
}
else
{
    Console.WriteLine("no");
}