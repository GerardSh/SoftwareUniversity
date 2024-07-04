using SOLID.Layouts;
using SOLID.ReportLevel;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        void Append(string datetime, ReportLevel.ReportLevel reportLevel, string message);
    }
}
