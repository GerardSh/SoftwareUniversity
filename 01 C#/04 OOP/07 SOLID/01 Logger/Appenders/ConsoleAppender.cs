using SOLID.Layouts;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            Console.WriteLine(string.Format(Layout.Format, datetime, reportLevel.ToString().ToUpper(), message));
            MessagesCounter++;
        }
    }
}
