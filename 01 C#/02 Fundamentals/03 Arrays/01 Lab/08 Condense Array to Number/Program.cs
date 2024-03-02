var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

if (arr.Length == 1)
{
    Console.WriteLine(arr[0]);
}

else
{
    string currentNumbers = string.Join(" ", arr);
    int sum = 0;

    bool multipleNumbers = true;


    while (true)
    {
        var arr2 = currentNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        if (arr2.Length > 2)
        {
            for (int i = 0; i < arr2.Length; i++)
            {
                if (i == 0)
                {
                    currentNumbers = "";
                }

                if (i == arr2.Length - 1)
                {
                    if (arr2.Length == 1)
                    {
                        sum += arr2[i];
                        currentNumbers += arr2[i];
                    }

                    continue;
                }
                else
                {
                    currentNumbers += arr2[i] + arr2[i + 1] + " ";
                }
            }
        }
        else
        {
            Console.WriteLine(arr2[0] + arr2[1]);
            break;
        }
    }
}

////2
//int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//int[] arr2 = new int[arr.Length - 1];

//int i = 0;

//while (arr.Length > 1)
//{
//    if (i == arr.Length - 1)
//    {
//        arr = arr2;
//        arr2 = new int[arr.Length - 1];
//        i = 0;
//    }
//    else
//    {
//        arr2[i] = arr[i] + arr[i + 1];
//        i++;
//    }
//}

//Console.WriteLine(arr[0]);

////3
//int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

//while (numbers.Length > 1)
//{
//    int[] condensedNumbers = new int[numbers.Length - 1];

//    for (int i = 0; i < condensedNumbers.Length; i++)
//    {
//        condensedNumbers[i] = numbers[i] + numbers[i + 1];
//    }

//    numbers = condensedNumbers;
//}

//Console.WriteLine(numbers[0]);