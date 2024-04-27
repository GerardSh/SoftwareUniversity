List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
int divisibleNumber = int.Parse(Console.ReadLine());

Predicate<int> remove = numb => numb % divisibleNumber == 0;

numbers.RemoveAll(remove);

Action<List<int>> reverseList = list => list.Reverse();

reverseList(numbers);

Console.WriteLine(string.Join(" ", numbers));