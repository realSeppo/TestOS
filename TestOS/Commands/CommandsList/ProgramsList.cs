using System;
using System.Collections.Generic;
using TestOS.Programs;

namespace TestOS.Commands
{
    public class ProgramsList : Command
    {
        public override string CommandWord => "Programs";
        List<Program> programs = new List<Program>() { new Calculator(), new FightGame() };

        public override bool Process(string input)
        {
            string programsListString = "Programs: " + Environment.NewLine;
            foreach (var program in programs)
            {
                programsListString += program.ProgramName + Environment.NewLine;
            }
            Console.WriteLine(programsListString + "You can open the program by writing its name or Exit");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(">> ");
            Console.ForegroundColor = Kernel.lettersColor;
            string programInput = Console.ReadLine();
            if (programInput == "Exit")
            {
                return true;
            }
            foreach (var program in programs)
            {
                if (program.ProgramName == programInput)
                {
                    Kernel.inProgram = true;
                    program.Process();
                    return true;
                }
            }
            return false;
        }
    }
}