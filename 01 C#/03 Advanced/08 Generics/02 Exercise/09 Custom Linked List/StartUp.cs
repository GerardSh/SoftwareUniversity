namespace ImplementDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            var intList = new CustomDoublyLinkedList<int>();

            intList.AddFirst(1);
            intList.AddFirst(0);
            intList.AddLast(2);
            intList.AddLast(3);

            intList.RemoveFirst();
            intList.RemoveLast();

            intList.ForEach(x => Console.WriteLine(x));

            int[] intArray = intList.ToArray();

            foreach (int x in intArray)
            {
                Console.WriteLine(x);
            }

            var stringList = new CustomDoublyLinkedList<string>();

            stringList.AddFirst("element 1");
            stringList.AddFirst("element 0");
            stringList.AddLast("element 2");
            stringList.AddLast("element 3");

            stringList.RemoveFirst();
            stringList.RemoveLast();

            stringList.ForEach(x => Console.WriteLine(x));

            string[] stringArray = stringList.ToArray();

            foreach (string x in stringArray)
            {
                Console.WriteLine(x);
            }
        }
    }
}