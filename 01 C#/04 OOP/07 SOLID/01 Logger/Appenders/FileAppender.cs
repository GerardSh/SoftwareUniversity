using SOLID.Layouts;
using SOLID.LogFiles;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout, ILogFile file)
            : base(layout)
        {
            LogFile = file;
        }

        public ILogFile LogFile { get; }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            string appendMessage = string.Format(Layout.Format, datetime, reportLevel.ToString().ToUpper(), message);

            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);

            LogFile.Write(appendMessage);

            MessagesCounter++;


        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {LogFile.Size}";
        }
    }
}
