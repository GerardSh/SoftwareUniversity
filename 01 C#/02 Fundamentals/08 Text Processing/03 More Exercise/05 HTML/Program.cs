using System.Text;

StringBuilder html = new StringBuilder();

html.AppendLine("<h1>\n" + "    " + Console.ReadLine() + "\n</h1>");
html.AppendLine("<article>\n" + "    " + Console.ReadLine() + "\n</article>");

string input;

while ((input = Console.ReadLine()) != "end of comments")
{
    html.AppendLine("<div>\n" + "    " + input + "\n</div>");
}

Console.WriteLine(html);