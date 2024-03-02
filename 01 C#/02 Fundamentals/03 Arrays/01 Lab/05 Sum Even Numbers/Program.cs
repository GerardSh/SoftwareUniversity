string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
int sum = 0;

foreach (int number in arr.Select(int.Parse))
{
    if (number % 2 == 0)
    {
        sum += number;
    }
}

Console.WriteLine(sum);

//2
//foreach (string s in arr)
//{
//if (int.Parse(s) % 2 == 0)
//    {
//        sum += int.Parse(s);
//    }
//}

//Console.WriteLine(sum);