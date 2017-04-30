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



    class Program
    {

        public static List<(Opcodes, short, short, short)> SampleProgram 
        = new List<(Opcodes, short, short, short)>() {
            (Opcodes.LOAD,0x1,0x0,0x0), //01 : LOAD R1 0
            (Opcodes.LOAD,0x2,0x1,0x0), //02 : LOAD R2 1
            (Opcodes.LOAD,0x4,010,0x0), //03 : LOAD R4 17
            (Opcodes.ADD ,0x1,0x2,0x3), //04 : ADD  R1 R2 R3
            (Opcodes.CMP ,0x3,0x4,0x0), //05 : CMP  R3 R4
            (Opcodes.JEQ ,0x8,0x0,0x0), //06 : JEQ  8
            (Opcodes.JUMP,0x4,0x0,0x0), //07 : JUMP 4 
            (Opcodes.HALT,0x0,0x0,0x0), //08 : HALT
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Orion Machine Code Emulator");
            Console.WriteLine("Copyright © 2017 Jumar Macato");
            var Core = new Orion.Core(SampleProgram);
            Core.Run();
            Console.Read();
        }
    }
}