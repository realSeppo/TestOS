using System;

namespace TestOS.Programs
{
    public class Calculator : Program
    {
        public override string ProgramName => "Calculator";

        public override void Process()
        {
            Console.WriteLine("Welcome to Test OS Calculator!" + Environment.NewLine + "To exit, write Exit, and to use, enter the operation with spaces between characters and operators.");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(">> ");
                Console.ForegroundColor = Kernel.lettersColor;

                string input = Console.ReadLine();
                string[] inputSplit = input.Split(' ');
                if (inputSplit.Length == 1 || inputSplit.Length > 3 || inputSplit.Length < 3)
                {
                    if (input == "Exit")
                    {
                        Kernel.inProgram = false;
                        return;
                    }
                    else
                    {
                        Error();
                        return;
                    }
                }
                else
                {
                    double output;
                    double number1 = 0;
                    double number2 = 0;
                    if(!Double.TryParse(inputSplit[0], out number1) || !Double.TryParse(inputSplit[2], out number2))
                    {
                        Error();
                        return;
                    }

                    switch (inputSplit[1])
                    {
                        default:
                            Error();
                            return;
                        case "+":
                            output = number1 + number2;
                            break;
                        case "-":
                            output = number1 - number2;
                            break;
                        case "*":
                            output = number1 * number2;
                            break;
                        case "/":
                            output = number1 / number2;
                            break;
                    }
                    Console.WriteLine(output);
                }
            }
        }
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown operation.");
            Console.ForegroundColor = Kernel.lettersColor;
            Process();
        }
    }
}
