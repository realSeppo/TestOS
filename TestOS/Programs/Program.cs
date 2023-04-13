namespace TestOS.Programs
{
    public abstract class Program : ProgramsMain
    {
        public abstract string ProgramName { get; }
        public abstract void Process();
    }
}