List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
int divisibleNumber = int.Parse(Console.ReadLine());

Predicate<int> remove = numb => numb % divisibleNumber == 0;

numbers.RemoveAll(remove);

Action<List<int>> reverseList = list => list.Reverse();

reverseList(numbers);

Console.WriteLine(string.Join(" ", numbers));




//2
List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
int divisibleNumber = int.Parse(Console.ReadLine());

Predicate<int> remove = numb => numb % divisibleNumber == 0;

for (int i = 0; i < numbers.Count; i++)
{
    if (remove(numbers[i]))
    {
        numbers.Remove(numbers[i--]);
    }
}

Func<List<int>, List<int>> reverseList = numbers =>
{
    List<int> numbersReversed = new List<int>(numbers.Count);

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        numbersReversed.Add(numbers[i]);
    }

    return numbersReversed;
};

Console.WriteLine(string.Join(" ", reverseList(numbers)));