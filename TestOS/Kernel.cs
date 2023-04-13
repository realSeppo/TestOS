using System;
using Sys = Cosmos.System;
using System.Collections.Generic;
using TestOS.Commands;

namespace TestOS
{
    public class Kernel : Sys.Kernel
    {
        public static string systemVersion = "0.1 Alpha";
        private string startText = "Welcome! Use the Help command to get information about the system.";
        public static ConsoleColor lettersColor = ConsoleColor.White;
        private List<Command> commands = new List<Command> { new Clear(), new ProgramsList(), new Reboot(), new TurnOff(), new Help(), new SetLettersColor(), new SysInfo() };
        public static bool inProgram;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine(startText);
        }

        protected override void Run()
        {
            if (!inProgram)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(">> ");
                Console.ForegroundColor = lettersColor;

                if (!CommandCheck())
                {
                    UnknownCommand();
                }
            }
        }
        private bool CommandCheck()
        {
            string input = Console.ReadLine();

            foreach (var command in commands)
            {
                if(input.StartsWith(command.CommandWord))
                {
                    if (command.Process(input))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        private void UnknownCommand()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown command.");
            Console.ForegroundColor = lettersColor;
        }
    }
}
