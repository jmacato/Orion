using System;

namespace Orion
{
    public class Constants
    {
        public static TimeSpan GlobalTickDurSpan = new TimeSpan(0, 0, 1);
        public enum InterruptDevicesEnum
        {
            KEYBOARD = 0xBEEF,
            DISPLAY = 0xFADE,
        }

        [FlagsAttribute]
        public enum SPFlagMasks
        {
            CF = 0b00000001,   // Carry Flag
            OF = 0b00000010,   // Overflow Flag
            PF = 0b00000100,   // Parity Flag
            NF = 0b00001000,   // Negative Flag
            EQ = 0b00010000,   // Equal Flag
            NQ = 0b00100000,   // Not Equal Flag
            LT = 0b01000000,   // Less Than Flag
            GT = 0b10000000    // Greater Than Flag
        }

        [FlagsAttribute]
        public enum InterrupFlagEnum
        {
            DR = 0b0000_0001,   // Device Ready
            OF = 0b0000_0010,   // Device Read Available
            PF = 0b0000_0100,   // Device Write Available
        }

        public enum Opcodes
        {
            LOAD,       // Load Literal to Register (LOAD [REG] [VAL])
            ADD,        // Addition, default at RHR when no result parameter is added (ADD [R1] [R2] [?RES])
            SUB,        // Subtraction, default at RHR when no result parameter is added (SUB [R1] [R2] [?RES])
            MULT,       // Multiplication, default at RHR when no result parameter is added (MULT [R1] [R2] [?RES])
            DIV,        // Add two results, default at RHR when no result parameter is added (DIV [DIVIDEND] [DIVISOR] [?RES])
            MOVE,       // Move src reg into dest reg, clearing the src reg to zero afterwards (MOVE [SRC] [DEST]) 
            COPY,       // Copy src reg to dest (COPY [SRC] [DEST])
            CMP,        // Compare Two Registers (CMP [A] [B])
            JUMP,       // Jump unconditionally to program address (JUMP [Program Address])
            JNE,        // Jump if NQ (Not Equal) flag is set (JNE [Program Address])
            JEQ,        // Jump if EQ (Equal) flag is set (JEQ [Program Address])
            JGT,        // Jump if GT (Greater Than) flag is set (JUMP [Program Address])
            JLT,        // Jump if LT (Less Than) flag is set (JUMP [Program Address])
            INTR,       // Read Interrupt (INTR [Interrupt Address])
            INTW,       // Write Interrupt (INTW [Interrupt Address])
            INTH,       // Set Interrupt Handler (INTH [Interrupt Address] [Program Address])
            HALT        // Stop Execution
        }

        public enum RegistersEnum
        {
            //  General Purpose Registers R1~R32
            R1 = 0x1, R2, R3, R4, R5, R6, R7, R8,
            R9, R10, R11, R12, R13, R14, R15,
            R16, R17, R18, R19, R20, R21, R22,
            R23, R24, R25, R26, R27, R28, R29,
            R30, R31, R32,
            
            IAR,    // Interrupt Address Register
            IDR,    // Interrupt Data Register
            IDA,     // Interrupt Flags

            RHR,    // Result Hold Register
            CHR,    // Last Call/Jump Address Hold Register

            MAR,    // Memory Address Register
            MBR,    // Memory Data Register

            PC,     // Program Counter
            IR,     // Instruction Register

            SR,      // Status Register

            HALT,    // Halt Bit
        }

   
    }

}