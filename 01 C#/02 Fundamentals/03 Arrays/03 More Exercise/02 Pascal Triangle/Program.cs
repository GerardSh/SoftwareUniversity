int n = int.Parse(Console.ReadLine());

int[] arr = { 1 };

Console.WriteLine(arr[0]);

for (int i = 2; i <= n; i++)
{
    int[] tempArr = new int[i];

    for (int j = 0; j < i; j++)
    {
        if (j == 0 || j == tempArr.Length - 1)
        {
            tempArr[j] = 1;
        }
        else
        {
            tempArr[j] = arr[j - 1] + arr[j];
        }
    }
    arr = tempArr;
    Console.WriteLine(string.Join(" ", tempArr));
}