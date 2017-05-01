/**************************************

    Orion Machine Code Emulator
    Program Constants
    Copyright © 2017 Jumar Macato
    
 **************************************/

using System;

namespace Orion
{
    public class Constants
    {
        /// <summary> Delay between instruction cycles </summary>
        public static TimeSpan GlobalTickDurSpan = new TimeSpan(0, 0, 0, 0, 0);

        /// <summary>
        ///  Addresses of all available interrupts
        /// </summary>
        public enum InterruptDevicesEnum
        {
            KEYBOARD = 0xBEEF,
            DISPLAY = 0xFADE,
        }

        [FlagsAttribute]
        public enum InterrupFlagEnum
        {
            DR = 0b0000_0001,   /// <summary> Device Ready </summary>
            OF = 0b0000_0010,   /// <summary> Device Read Available </summary>
            PF = 0b0000_0100,   /// <summary> Device Write Available </summary>
        }

        /// <summary>
        ///  Enumerates all supported instructions
        /// </summary>
        public enum Opcodes
        {
            /// <summary> Load Literal to Register (LOAD [REG] [VAL]) </summary>
            LOAD,
            /// <summary> Addition, default at RHR when no result parameter is added (ADD [R1] [R2] [?Optional Dest. Reg.]) </summary>
            ADD,
            /// <summary> Subtraction, default at RHR when no result parameter is added (SUB [R1] [R2] [?Optional Dest. Reg.]) </summary>
            SUB,
            /// <summary> Multiplication, default at RHR when no result parameter is added (MULT [R1] [R2] [?Optional Dest. Reg.]) </summary>
            MULT,
            /// <summary> Add two results, default at RHR when no result parameter is added (DIV [Dividend Register] [Divisor Register] [?Optional Dest. Reg.]) </summary>
            DIV,
            /// <summary> Move src reg into dest reg, clearing the src reg to zero afterwards (MOVE [Source Register] [Dest Register])  </summary>
            MOVE,
            /// <summary> Copy src reg to dest (COPY [Source Register] [Dest Register]) </summary>
            COPY,
            /// <summary> Compare Two Registers (CMP [Register A] [Register B]) </summary>
            CMP,
            /// <summary> Jump unconditionally to program address (JUMP [Program Address]) </summary>
            JUMP,
            /// <summary> Jump unconditionally to program address specified in the register (JUMP [Register]) </summary>
            JREG,
            /// <summary> Jump if NQ (Not Equal) flag is set (JNE [Program Address]) </summary>
            JNE,
            /// <summary> Jump if EQ (Equal) flag is set (JEQ [Program Address]) </summary>
            JEQ,
            /// <summary> Jump if GT (Greater Than) flag is set (JUMP [Program Address]) </summary>
            JGT,
            /// <summary> Jump if LT (Less Than) flag is set (JUMP [Program Address]) </summary>
            JLT,
            /// <summary> Read Interrupt (INTR [Interrupt Address]) </summary>
            INTR,
            /// <summary> Write Interrupt (INTW [Interrupt Address]) </summary>
            INTW,
            /// <summary> Set Interrupt Handler (INTH [Interrupt Address] [Program Address]) </summary>
            INTH,
            /// <summary> Stop Execution </summary>
            HALT
        }

        public enum RegistersEnum
        {
            /// <summary> General Purpose Register 1 </summary>
            R1 = 0x01,
            /// <summary> General Purpose Register 2 </summary>
            R2,
            /// <summary> General Purpose Register 3 </summary>
            R3,
            /// <summary> General Purpose Register 4 </summary> 
            R4,
            /// <summary> General Purpose Register 5 </summary> 
            R5,
            /// <summary> General Purpose Register 6 </summary> 
            R6,
            /// <summary> General Purpose Register 7 </summary> 
            R7,
            /// <summary> General Purpose Register 8 </summary> 
            R8,
            /// <summary> General Purpose Register 9 </summary> 
            R9,
            /// <summary> General Purpose Register 10 </summary> 
            R10,
            /// <summary> General Purpose Register 11 </summary> 
            R11,
            /// <summary> General Purpose Register 12 </summary> 
            R12,
            /// <summary> General Purpose Register 13 </summary> 
            R13,
            /// <summary> General Purpose Register 14 </summary> 
            R14,
            /// <summary> General Purpose Register 15 </summary> 
            R15,
            /// <summary> General Purpose Register 16 </summary> 
            R16,
            /// <summary> General Purpose Register 17 </summary> 
            R17,
            /// <summary> General Purpose Register 18 </summary> 
            R18,
            /// <summary> General Purpose Register 19 </summary> 
            R19,
            /// <summary> General Purpose Register 20 </summary> 
            R20,
            /// <summary> General Purpose Register 21 </summary> 
            R21,
            /// <summary> General Purpose Register 22 </summary> 
            R22,
            /// <summary> General Purpose Register 23 </summary> 
            R23,
            /// <summary> General Purpose Register 24 </summary> 
            R24,
            /// <summary> General Purpose Register 25 </summary> 
            R25,
            /// <summary> General Purpose Register 26 </summary> 
            R26,
            /// <summary> General Purpose Register 27 </summary> 
            R27,
            /// <summary> General Purpose Register 28 </summary> 
            R28,
            /// <summary> General Purpose Register 29 </summary> 
            R29,
            /// <summary> General Purpose Register 30 </summary> 
            R30,
            /// <summary> General Purpose Register 31 </summary> 
            R31,
            /// <summary> General Purpose Register 32 </summary> 
            R32,
            /// <summary> Interrupt Address Register </summary>
            IAR,
            /// <summary> Interrupt Data Register </summary>
            IDR,
            /// <summary> Interrupt Flags </summary>
            IDA,
            /// <summary> Result Hold Register </summary>
            RHR,
            /// <summary> Last Call/Jump Address Hold Register </summary>
            CHR,
            /// <summary> Memory Address Register </summary>
            MAR,
            /// <summary> Memory Data Register </summary>
            MBR,
            /// <summary> Program Counter </summary>
            PC,
            /// <summary> Instruction Register </summary>
            IR,
            /// <summary> Halt Bit </summary>
            HALT,
            /// <summary> Carry Flag </summary>
            CF,
            /// <summary> Overflow Flag </summary>
            OF,
            /// <summary> Parity Flag </summary>
            PF,
            /// <summary> Negative Flag </summary>
            NF,
            /// <summary> Equal Flag </summary>
            EQ,
            /// <summary> Not Equal Flag </summary>
            NQ,
            /// <summary> Less Than Flag </summary>
            LT,
            /// <summary> Greater Than Flag </summary>
            GT
        }
    }
}