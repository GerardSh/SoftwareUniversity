int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] arr2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int sum = 0;
bool isIdentical = true;

for (int i = 0; i < arr.Length && isIdentical; i++)
{
    if (arr[i] == arr2[i])
    {
        sum += arr[i];

        if (i == arr.Length - 1)
        {
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
    else
    {
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        isIdentical = false;
    }
}