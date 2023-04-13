using System;

namespace TestOS.Commands
{
    class SetLettersColor : Command
    {
        public override string CommandWord => "SetLettersColor";

        public override bool Process(string input)
        {
            string[] inputSplit = input.Split(' ');
            if(inputSplit.Length > 2 || inputSplit.Length == 1)
            {
                return false;
            }
            switch (inputSplit[1])
            {
                default:
                    return false;
                case "Red":
                    Kernel.lettersColor = ConsoleColor.Red;
                    return true;
                case "Green":
                    Kernel.lettersColor = ConsoleColor.Green;
                    return true;
                case "White":
                    Kernel.lettersColor = ConsoleColor.White;
                    return true;
                case "Blue":
                    Kernel.lettersColor = ConsoleColor.Blue;
                    return true;
            }
        }
    }
}
