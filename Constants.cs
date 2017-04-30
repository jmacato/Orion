using System;

namespace Orion
{
    public class Constants
    {

        [FlagsAttribute]
        public enum SPFlagMasks
        {
            CF = 0b0000_0001,   //Carry Flag
            OF = 0b0000_0010,   //Overflow Flag
            PF = 0b0000_0100,   //Parity Flag
            NF = 0b0000_1000,   //Negative Flag
            EQ = 0b0001_0000,   //Equal Flag
            NQ = 0b0010_0000,   //Not Equal Flag
            LT = 0b0100_0000,   //Less Than Flag
            GT = 0b1000_0000    //Greater Than Flag
        }

        public enum Opcodes
        {
            LOAD,       //Load Literal to Register (LOAD [REG] [VAL])
            ADD,        //Addition, default at RHR when no result parameter is added (ADD [R1] [R2] [?RES])
            SUB,        //Subtraction, default at RHR when no result parameter is added (SUB [R1] [R2] [?RES])
            MULT,       //Multiplication, default at RHR when no result parameter is added (MULT [R1] [R2] [?RES])
            DIV,        //Add two results, default at RHR when no result parameter is added (DIV [DIVIDEND] [DIVISOR] [?RES])
            MOVE,       //Move src reg into dest reg, clearing the src reg to zero afterwards (MOVE [SRC] [DEST]) 
            COPY,       //Copy src reg to dest (COPY [SRC] [DEST])
            JUMP,       //Jump unconditionally to program address (JUMP [Program Address])
            JNE,        //Jump if NQ (Not Equal) flag is set (JNE [Program Address])
            JEQ,        //Jump if EQ (Equal) flag is set (JEQ [Program Address])
            JGT,        //Jump if GT (Greater Than) flag is set (JUMP [Program Address])
            JLT,        //Jump if LT (Less Than) flag is set (JUMP [Program Address])
            INTR,       // Read Interrupt (INTR [Interrupt Address])
            INTH,       // Set Interrupt Handler (INTH [Interrupt Address] [Program Address])
        }

        public struct Registers
        {
            // General Purpose Registers R1~R32
            Int16 R1;
            Int16 R2;
            Int16 R3;
            Int16 R4;
            Int16 R5;
            Int16 R6;
            Int16 R7;
            Int16 R8;
            Int16 R9;
            Int16 R10;
            Int16 R11;
            Int16 R12;
            Int16 R13;
            Int16 R14;
            Int16 R15;
            Int16 R16;
            Int16 R17;
            Int16 R18;
            Int16 R19;
            Int16 R20;
            Int16 R21;
            Int16 R22;
            Int16 R23;
            Int16 R24;
            Int16 R25;
            Int16 R26;
            Int16 R27;
            Int16 R28;
            Int16 R29;
            Int16 R30;
            Int16 R31;
            Int16 R32;

            Int16 IAR;    //Interrupt Address Register
            Int16 IDR;    //Interrupt Data Register
            byte IDA;     //Interrupt Data Available

            Int16 RHR;    //Result Hold Register

            Int16 MAR;    //Memory Address Register
            Int16 MBR;    //Memory Data Register

            Int16 PC;     //Program Counter
            Int16 IR;     //Instruction Register

            byte SR;     //Status Register
        }
    }
}