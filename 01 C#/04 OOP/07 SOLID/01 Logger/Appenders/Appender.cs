using SOLID.Layouts;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; }

        public int MessagesCounter { get; set; }

        public abstract void Append(string datetime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCounter}";
        }
    }
}
