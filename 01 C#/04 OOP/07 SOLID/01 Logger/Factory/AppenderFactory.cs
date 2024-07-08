using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.LogFiles;
using SOLID.ReportLevels;

namespace SOLID.Factory
{
    public class AppenderFactory
    {
        public IAppender Create(ILayout layout, string type, string level)
        {
            IAppender appender = null;

            if (type == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout);
            }
            else if (type == nameof(FileAppender))
            {
                appender = new FileAppender(layout, new LogFile());
            }
            else
            {
                throw new ArgumentException();
            }

            if (level != null)
            {
                //1
                bool isValidLogLevel = Enum.TryParse(level, true, out ReportLevel reportLevel);

                if (isValidLogLevel)
                {
                    appender.ReportLevel = reportLevel;
                }

                //2
                //if (level == "INFO")
                //{
                //    appender.ReportLevel = ReportLevel.Info;
                //}
                //else if (level == "WARNING")
                //{
                //    appender.ReportLevel = ReportLevel.Warning;
                //}
                //else if (level == "CRITICAL")
                //{
                //    appender.ReportLevel = ReportLevel.Critical;
                //}
                //else
                //{
                //    appender.ReportLevel = ReportLevel.Fatal;
                //}
            }

            return appender;
        }
    }
}
