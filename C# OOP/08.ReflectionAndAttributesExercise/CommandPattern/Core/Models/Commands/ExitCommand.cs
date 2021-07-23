namespace CommandPattern.Core.Models.Commands
{
    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
