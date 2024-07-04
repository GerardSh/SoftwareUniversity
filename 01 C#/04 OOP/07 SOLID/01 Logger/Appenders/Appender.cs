using SOLID.Layouts;
using SOLID.ReportLevel;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public abstract void Append(string datetime, ReportLevel.ReportLevel reportLevel, string message);
    }
}
