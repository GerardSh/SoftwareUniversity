using System.Text;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Stack<string> stack = new Stack<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];

                if (command == "Push")
                {
                    stack.Push(elements.Skip(1).ToArray());
                }
                else if (command == "Pop")
                {
                    if (stack.HasElements())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (string number in stack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}