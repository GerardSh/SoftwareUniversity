using System.Text;

Queue<int> numbers = new Queue<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

while (numbers.Count > 0)
{
    if (numbers.Peek() % 2 == 0)
    {
        if (numbers.Count > 1)
        {
            Console.Write(numbers.Dequeue() + ", ");
        }
        else
        {
            Console.Write(numbers.Dequeue());
        }
    }
    else
    {
        numbers.Dequeue();
    }
}