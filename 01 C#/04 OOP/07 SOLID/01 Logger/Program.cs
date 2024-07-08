using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.Loggers;
using SOLID.Factory;

namespace SOLID
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string currentType = input[0];
                string currentLayout = input[1];
                string currentLevel = null;

                ILayout layout = layoutFactory.Create(currentLayout);

                IAppender appender = appenderFactory.Create(layout, currentType, currentLevel);

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

            Console.WriteLine("Logger info");

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}