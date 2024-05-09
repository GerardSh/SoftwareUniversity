namespace ImplementingCustomList
{
    public class StartUp
    {
        static void Main()
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(4);

            list.Print();

            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.Contains(5));

            list.InsertAt(0, 0);
            list.InsertAt(3, 3);

            list.Print();

            list.RemoveAt(0);
            list.RemoveAt(3);

            list.Print();

            list.RemoveAt(1);

            list.Print();

            list.Swap(0, 1);

            list.Print();

            list.Swap(1, 0);

            list.Print();

            list.Swap(0, 0);

            list.Print();
        }
    }
}
