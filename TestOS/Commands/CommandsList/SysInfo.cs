using System;

namespace TestOS.Commands
{
    class SysInfo : Command
    {
        public override string CommandWord => "SysInfo";

        public override bool Process(string input)
        {
            Console.WriteLine("System version - " + Kernel.systemVersion + Environment.NewLine + "CPU vendor - " + Cosmos.Core.CPU.GetCPUVendorName() + Environment.NewLine + "RAM - " + Cosmos.Core.CPU.GetAmountOfRAM() + " MB");
            return true;
        }
    }
}
