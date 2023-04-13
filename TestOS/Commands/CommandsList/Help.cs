using System;

namespace TestOS.Commands
{
    class Help : Command
    {
        public override string CommandWord => "Help";

        public override bool Process(string input)
        {
            Console.WriteLine("Commands: " + Environment.NewLine + "TurnOff - turn off computer" + Environment.NewLine + "Clear - clear console" + Environment.NewLine + "Reboot - reboot computer" + Environment.NewLine + "SysInfo - get information about system" + Environment.NewLine + "SetLettersColor \"color\" - set letters color. Colors: Red, Green, White, Blue" + Environment.NewLine + "Programs - open any program on the computer ");
            return true;
        }
    }
}
