using SOLID.Layouts;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCounter { get; protected set; }

        void Append(string datetime, ReportLevel reportLevel, string message);
    }
}
