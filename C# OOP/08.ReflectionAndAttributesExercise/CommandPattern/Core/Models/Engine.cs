namespace CommandPattern.Core.Models
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string commandArgs = Console.ReadLine();

                string result = _commandInterpreter.Read(commandArgs);

                if (result is null)
                {
                    break;
                }

                Console.WriteLine(result);
            }

        }
    }
}
