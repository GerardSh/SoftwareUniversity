namespace ImplementingCustomList
{
    public class StartUp
    {
        static void Main()
        {
            CustomList<int> intList = new CustomList<int>();

            intList.Add(1);
            intList.Add(2);
            intList.Add(4);

            intList.Print();

            Console.WriteLine(intList.Contains(2));
            Console.WriteLine(intList.Contains(5));

            intList.InsertAt(0, 0);
            intList.InsertAt(3, 3);

            intList.Print();

            intList.RemoveAt(0);
            intList.RemoveAt(3);

            intList.Print();

            intList.RemoveAt(1);

            intList.Print();

            intList.Swap(0, 1);

            intList.Print();

            intList.Swap(1, 0);

            intList.Print();

            intList.Swap(0, 0);

            intList.Print();

            CustomList<string> stringList = new CustomList<string>();

            stringList.Add("1");
            stringList.Add("2");
            stringList.Add("4");

            stringList.Print();

            Console.WriteLine(intList.Contains(2));
            Console.WriteLine(intList.Contains(5));

            stringList.InsertAt(0, "0");
            stringList.InsertAt(3, "3");

            stringList.Print();

            stringList.RemoveAt(0);
            stringList.RemoveAt(3);

            stringList.Print();

            stringList.RemoveAt(1);

            stringList.Print();

            stringList.Swap(0, 1);

            stringList.Print();

            stringList.Swap(1, 0);

            stringList.Print();

            stringList.Swap(0, 0);

            stringList.Print();
        }
    }
}
