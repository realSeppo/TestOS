namespace TestOS.Commands
{
    public abstract class Command : CommandsMain
    {
        public abstract string CommandWord { get; }
        public abstract bool Process(string input);
    }
}