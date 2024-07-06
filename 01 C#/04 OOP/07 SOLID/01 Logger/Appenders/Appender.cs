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

        public abstract void Append(string datetime, ReportLevel reportLevel, string message);
    }
}
