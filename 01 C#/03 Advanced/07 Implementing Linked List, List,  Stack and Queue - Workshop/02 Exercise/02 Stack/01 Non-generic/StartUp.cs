namespace ImplementingCustomStack
{
    internal class StartUp
    {
        static void Main()
        {
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);


            var stack2 = new CustomStack();

            stack.ForEach(x =>
            {
                stack2.Push(x);
            });

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
        }
    }
}
