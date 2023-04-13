using Sys = Cosmos.System;

namespace TestOS.Commands
{
    class TurnOff : Command
    {
        public override string CommandWord => "TurnOff";

        public override bool Process(string input)
        {
            Sys.Power.Shutdown();
            return true;
        }
    }
}
