namespace TestOS.Commands
{
    public interface CommandsMain
    {
        string CommandWord { get; }
        bool Process(string input);
    }
}