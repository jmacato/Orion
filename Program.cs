/* 

    Orion Machine Code Emulator
    Copyright © 2017 Jumar Macato

    THIS PROJECT IS UNDER MIT LICENSE.
    
 */

using System;

using System.Collections.Generic;
using System.Linq;
using static Orion.Constants;
namespace Orion
{


    public List<(Opcodes, short, short, short)> SampleProgram = new List<(Opcodes, short, short, short)>();

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Orion Machine Code Emulator");
            Console.WriteLine("Copyright © 2017 Jumar Macato");

            if (args.Count() > 0)
            {
                var Args = args[0];
                var Args2 = args[1];

                switch (Args)
                {
                    case "open":
                        break;
                    default:

                        Console.WriteLine("Invalid Argument: " + String.Join(" ", args.ToList()));
                        break;
                }

            }

            var exec = new Orion.ExecutionUnit();
            exec.ExecuteInstruction(Orion.Constants.Opcodes.ADD, 0, 0, 0);
            Console.ReadKey();
        }
    }
}