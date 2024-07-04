using SOLID.Appenders;
using SOLID.ReportLevel;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            Appender = appender;
        }

        public IAppender Appender { get; }

        public void Critical(string dateTime, string message)
        {
            Appender.Append(dateTime, ReportLevel.ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            Appender.Append(dateTime, ReportLevel.ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Appender.Append(dateTime, ReportLevel.ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Appender.Append(dateTime, ReportLevel.ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Appender.Append(dateTime, ReportLevel.ReportLevel.Warning, message);
        }
    }
}
