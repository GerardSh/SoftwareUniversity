using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public abstract class Test
    {
        public abstract void Tess();
    }

   public abstract class Test2 : Test
    {
        public override void Tess()
        {
            throw new System.NotImplementedException();
        }
    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
