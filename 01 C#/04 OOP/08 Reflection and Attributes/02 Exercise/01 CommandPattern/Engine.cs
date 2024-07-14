using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {

        }
    }
}
