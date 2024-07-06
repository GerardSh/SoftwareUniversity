using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.Loggers;
using SOLID.LogFiles;
using SOLID.ReportLevels;

namespace SOLID
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                IAppender appender = MakeAppender(input);

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string messagesData;

            while ((messagesData = Console.ReadLine()) != "END")
            {
                string[] messages = messagesData.Split("|");

                string currentReportLevel = messages[0];
                string currentDate = messages[1];
                string currentMessage = messages[2];

                if (currentReportLevel == "INFO")
                {
                    logger.Info(currentDate, currentMessage);
                }
                else if (currentReportLevel == "WARNING")
                {
                    logger.Warning(currentDate, currentMessage);
                }
                else if (currentReportLevel == "ERROR")
                {
                    logger.Error(currentDate, currentMessage);
                }
                else if (currentReportLevel == "CRITICAL")
                {
                    logger.Critical(currentDate, currentMessage);
                }
                else if (currentReportLevel == "FATAL")
                {
                    logger.Fatal(currentDate, currentMessage);
                }
            }
        }
        private static IAppender MakeAppender(string[] input)
        {
            string currentType = input[0];
            string currentLayout = input[1];
            string currentLevel = null;

            if (input.Length > 2)
            {
                currentLevel = input[2];
            }

            ILayout layout = new SimpleLayout();

            if (currentLayout == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else
            {
                layout = new XmlLayout();
            }

            IAppender appender = null;

            if (currentType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else
            {
                appender = new FileAppender(layout, new LogFile());
            }

            if (currentLevel != null)
            {
                if (currentLevel == "INFO")
                {
                    appender.ReportLevel = ReportLevel.Info;
                }
                else if (currentLevel == "WARNING")
                {
                    appender.ReportLevel = ReportLevel.Warning;
                }
                else if (currentLevel == "CRITICAL")
                {
                    appender.ReportLevel = ReportLevel.Critical;
                }
                else
                {
                    appender.ReportLevel = ReportLevel.Fatal;
                }
            }

            return appender;
        }
    }
}