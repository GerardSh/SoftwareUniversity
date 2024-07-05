using System.Text;

namespace SOLID.LogFiles
{
    public interface ILogFile
    {
        public int Size { get; }

        public void Write(string message);
    }
}
