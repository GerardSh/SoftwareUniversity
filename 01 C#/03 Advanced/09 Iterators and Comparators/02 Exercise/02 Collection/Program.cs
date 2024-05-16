using System.Text;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            ListyIterator<string> iterator;

            List<string> input = Console.ReadLine().Split().Skip(1).ToList();

            iterator = new ListyIterator<string>(input);

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
                else if (command == "PrintAll")
                {
                    var sb = new StringBuilder();

                    foreach (string item in iterator)
                    {
                        sb.Append(item + " ");
                    }

                    Console.WriteLine(sb.ToString().TrimEnd());
                }
            }
        }
    }
}