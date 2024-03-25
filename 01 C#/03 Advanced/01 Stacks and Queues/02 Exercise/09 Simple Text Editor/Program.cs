using System.Text;
using System.Text.RegularExpressions;

int numberOfOperations = int.Parse(Console.ReadLine());
StringBuilder text = new StringBuilder("");
Stack<string> textVersions = new Stack<string>();

for (int i = 0; i < numberOfOperations; i++)
{
    string[] elements = Regex.Split(Console.ReadLine(), @" ");

    int command = int.Parse(elements[0]);
    string arg = elements.Length > 1 ? elements[1] : null;

    if (command == 1)
    {
        string textToAdd = arg;

        textVersions.Push(text.ToString());
        text.Append(textToAdd);
    }
    else if (command == 2)
    {
        int elementsToDelete = int.Parse(arg);

        textVersions.Push(text.ToString());
        text.Remove(text.Length - elementsToDelete, elementsToDelete);

        //sec variant
        //while (elementsToDelete-- > 0)
        //{
        //    text.Remove(text.Length - 1, 1);
        //}
    }
    else if (command == 3)
    {
        int index = int.Parse(arg);

        if (index <= text.Length)
        {
            Console.WriteLine(text[index - 1]);
        }
    }
    else if (command == 4)
    {
        text = new StringBuilder(textVersions.Pop());
    }
}