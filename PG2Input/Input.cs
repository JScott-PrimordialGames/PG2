using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG2Input
{
    public static class Input
    {
        public static int ReadInteger(string prompt, int min, int max)
        {
            double dVal = 5;
            int iVal = (int)dVal;

            while (true)
            {
                Console.Write(prompt);
                string StringInput = Console.ReadLine();
                int input;
                if (int.TryParse(StringInput, out input))
                {
                    if (input >= min && input <= max)
                        return input;
                       
                }

                Console.WriteLine("That is not a valid input, please try again.");
            }
        }

        public static void ReadString(string prompt, ref string value)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    value = input;
                    return;
                }
                else
                    Console.WriteLine("No input detected, please try again");
            }
        }

        public static void ReadChoice(string propmpt, string[] options, out int selection)
        {
            foreach (string option in options)
                Console.WriteLine(option);
            selection = ReadInteger(propmpt, 1, options.Length);
            return;
        }
    }
}
