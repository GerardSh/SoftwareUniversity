namespace ImplementDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            var list = new CustomDoublyLinkedList();

            list.AddFirst(3);

            list.AddFirst(2);
            list.AddFirst(1);
            list.AddFirst(0);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);

            list.RemoveFirst();
            list.RemoveLast();

            list.ForEach(x => Console.WriteLine(x));

            int[] array = list.ToArray();

            foreach (int x in array)
            {
                Console.WriteLine(x);
            }
        }
    }
}