namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            ListyIterator<string> iterator;

            List<string> list = Console.ReadLine().Split().Skip(1).ToList();

            iterator = new ListyIterator<string>(list);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "Print")
                {
                    iterator.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
            }
        }
    }
}