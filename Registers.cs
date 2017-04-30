using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Orion
{
    public class Registers
    {
        //  General Purpose Registers R1~R32
        public Int16 R1, R2, R3, R4, R5, R6, R7, R8,
              R9, R10, R11, R12, R13, R14, R15,
              R16, R17, R18, R19, R20, R21, R22,
              R23, R24, R25, R26, R27, R28, R29,
              R30, R31, R32;
        public Int16 IAR;    // Interrupt Address Register
        public Int16 IDR;    // Interrupt Data Register
        public byte IDA;     // Interrupt Flags

        public Int16 RHR;    // Result Hold Register
        public Int16 CHR;    // Last Call/Jump Address Hold Register

        public Int16 MAR;    // Memory Address Register
        public Int16 MBR;    // Memory Data Register

        public Int16 PC;     // Program Counter
        public Int16 IR;     // Instruction Register

        public byte SR;      // Status Register

        public bool HALT;    // Halt Bit

        List<FieldInfo> CurFieldInfo = typeof(Registers).GetFields().ToList();
        public void Set(string RegisterName, object value)
        {
            if (CurFieldInfo.Where(p => p.Name == RegisterName).Any())
            {
                 FieldInfo x = CurFieldInfo.Where(p => p.Name == RegisterName).First();
/*
                Type type = this.GetType();
                PropertyInfo prop = type.GetProperty(RegisterName);
*/
                switch (value)
                {
                    case Int16 o:
                        x.SetValue(this, o);
                        break;
                    case bool o:
                        x.SetValue(this, o);
                        break;
                    case byte o:
                        x.SetValue(this, o);

                        break;
                    default:
                        throw new InvalidCastException($"Can't set value \"{value}\" into Register {RegisterName}.");
                }

            }
            else
            {
                throw new InvalidProgramException($"Can't find Register {RegisterName}.");
            }

        }
    }
}