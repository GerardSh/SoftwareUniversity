using SOLID.Appenders;
using SOLID.ReportLevel;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ReportLevel.Critical, message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ReportLevel.Error, message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ReportLevel.Fatal, message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ReportLevel.Info, message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ReportLevel.Warning, message);
            }
        }
    }
}
