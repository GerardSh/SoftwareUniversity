namespace ImplementingCustomStack
{
    internal class StartUp
    {
        static void Main()
        {
            CustomStack<int> intStack = new CustomStack<int>();

            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            intStack.Push(4);
            intStack.Push(5);

            var intStack2 = new CustomStack<int>();

            intStack.ForEach(x =>
            {
                intStack2.Push(x);
            });

            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());

            Console.WriteLine(intStack.Peek());
            Console.WriteLine(intStack.Peek());

            CustomStack<string> stringStack = new CustomStack<string>();

            stringStack.Push("1");
            stringStack.Push("2");
            stringStack.Push("3");
            stringStack.Push("4");
            stringStack.Push("5");

            var stringStack2 = new CustomStack<string>();

            stringStack.ForEach(x =>
            {
                stringStack2.Push(x);
            });

            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Pop());

            Console.WriteLine(stringStack.Peek());
            Console.WriteLine(stringStack.Peek());
        }
    }
}
