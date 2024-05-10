namespace ImplementingCustomQueue
{
    internal class StartUp
    {
        static void Main()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            CustomQueue<string> queue2 = new CustomQueue<string>();

            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                queue2.Enqueue(queue.Dequeue().ToString());
            }

            queue2.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(queue2.Dequeue());
            Console.WriteLine(queue2.Dequeue());
            Console.WriteLine(queue2.Dequeue());
            Console.WriteLine(queue2.Dequeue());

            Console.WriteLine(queue2.Peek());
            Console.WriteLine(queue2.Peek());

            queue2.Clear();

            Console.WriteLine(queue2.Count);
        }
    }
}