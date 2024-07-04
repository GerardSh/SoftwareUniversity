using SOLID.Layouts;
using SOLID.ReportLevel;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel.ReportLevel reportLevel, string message)
        {
            string appendMessage = string.Format(Layout.Format, datetime, reportLevel, message);

            File.AppendAllText(FilePath, appendMessage);
        }
    }
}
