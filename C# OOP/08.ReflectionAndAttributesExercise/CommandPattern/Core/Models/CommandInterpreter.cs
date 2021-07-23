namespace CommandPattern.Core.Models
{
    using Contracts;
    using System;
    using Commands;
    using System.Reflection;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string _commandSuffix = "Command";

        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = $"{tokens[0]}{_commandSuffix}";
            string[] commandArgs = tokens[1..];

            Type commandClassType = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == commandName);

            if (commandClassType is null)
            {
                throw new InvalidOperationException("Invalid command type");
            }

            ICommand commandClassInstance = (ICommand)Activator.CreateInstance(commandClassType);

            return commandClassInstance.Execute(commandArgs);
        }
    }
}
