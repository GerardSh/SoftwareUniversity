namespace ImplementDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            var intList = new CustomDoublyLinkedList<int>();

            intList.AddFirst(3);
            intList.AddFirst(2);
            intList.AddFirst(1);
            intList.AddFirst(0);

            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            var stringList = new CustomDoublyLinkedList<string>();

            stringList.AddFirst("element 3");
            stringList.AddFirst("element 2");
            stringList.AddFirst("element 1");
            stringList.AddFirst("element 0");

            foreach (var item in stringList)
            {
                Console.WriteLine(item);
            }
        }
    }
}