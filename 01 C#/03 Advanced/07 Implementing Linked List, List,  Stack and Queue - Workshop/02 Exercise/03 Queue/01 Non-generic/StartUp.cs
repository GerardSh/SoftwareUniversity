namespace ImplementingCustomQueue
{
    internal class StartUp
    {
        static void Main()
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            var queue2 = new CustomQueue();

            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                queue2.Enqueue(queue.Dequeue());
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