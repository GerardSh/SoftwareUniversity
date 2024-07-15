using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandData = args.Split();

            string commandName = commandData[0] + "Command";
            string[] arguments = commandData.Skip(1).ToArray();

            string result = null;
            ICommand command = null;

            //Without reflection
            //if (commandName == nameof(HelloCommand))
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == nameof(ExitCommand))
            //{
            //    command = new ExitCommand();
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid command");
            //}

            //result = command.Execute(arguments);

            //With reflection - it will catch any other ICommand class we create in the future and the below code will work without the need of modification.
            Type type = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == commandName).FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }
            else
            {
                //1
                var typeObject = Activator.CreateInstance(type) as ICommand;

                if (typeObject == null)
                {
                    throw new InvalidCastException("Invalid command class");
                }

                result = typeObject.Execute(arguments);

                //2
                //MethodInfo method = type.GetMethod("Execute");
                //var typeObject = Activator.CreateInstance(type);

                //result = method.Invoke(typeObject, new object[] { arguments }).ToString();
            }

            return result;
        }
    }
}
