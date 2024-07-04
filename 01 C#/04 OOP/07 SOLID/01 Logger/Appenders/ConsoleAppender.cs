using SOLID.Layouts;
using SOLID.ReportLevel;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel.ReportLevel reportLevel, string message)
        {
            Console.WriteLine(string.Format(Layout.Format, datetime, reportLevel, message));
        }
    }
}
