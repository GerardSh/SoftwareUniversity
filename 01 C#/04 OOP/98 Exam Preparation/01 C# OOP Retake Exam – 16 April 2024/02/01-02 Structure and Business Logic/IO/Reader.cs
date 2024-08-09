using TheContentDepartment.IO.Contracts;

namespace TheContentDepartment.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
