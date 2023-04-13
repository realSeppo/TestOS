using System;

namespace TestOS.Commands
{
    class Clear : Command
    {
        public override string CommandWord => "Clear";

        public override bool Process(string input)
        {
            Console.Clear();
            return true;
        }
    }
}
