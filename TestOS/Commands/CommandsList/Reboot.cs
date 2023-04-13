using Sys = Cosmos.System;

namespace TestOS.Commands
{
    class Reboot : Command
    {
        public override string CommandWord => "Reboot";

        public override bool Process(string input)
        {
            Sys.Power.Reboot();
            return true;
        }
    }
}
