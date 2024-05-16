namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            ListyIterator<string> iterator;

            string[] input = Console.ReadLine().Split();

            iterator = new ListyIterator<string>(input.Skip(1).ToList());

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