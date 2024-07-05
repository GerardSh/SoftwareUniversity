using System.Text;

namespace SOLID.LogFiles
{
    public class LogFile : ILogFile
    {
        StringBuilder stringBuilder;

        public LogFile()
        {
            stringBuilder = new StringBuilder();
        }

        public int Size => stringBuilder.ToString().Where(x => char.IsLetter(x)).Sum(x => x);

        public void Write(string message)
        {
            stringBuilder.Append(message);
        }
    }
}
