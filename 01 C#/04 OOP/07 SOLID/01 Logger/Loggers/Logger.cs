using SOLID.Appenders;
using SOLID.ReportLevels;

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
            Log(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Warning, message);
        }

        void Log(string dateTime, ReportLevel level, string message)
        {
            foreach (var appender in Appenders)
            {
                if (level >= appender.ReportLevel)
                {
                    appender.Append(dateTime, level, message);
                }
            }
        }
    }
}
