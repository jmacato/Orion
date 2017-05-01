using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Orion
{
    public class Registers
    {
        /// <summary> General Purpose Register 1 </summary>
        public Int16 R1;
        /// <summary> General Purpose Register 2 </summary>
        public Int16 R2;
        /// <summary> General Purpose Register 3 </summary>
        public Int16 R3;
        /// <summary> General Purpose Register 4 </summary> 
        public Int16 R4;
        /// <summary> General Purpose Register 5 </summary> 
        public Int16 R5;
        /// <summary> General Purpose Register 6 </summary> 
        public Int16 R6;
        /// <summary> General Purpose Register 7 </summary> 
        public Int16 R7;
        /// <summary> General Purpose Register 8 </summary> 
        public Int16 R8;
        /// <summary> General Purpose Register 9 </summary> 
        public Int16 R9;
        /// <summary> General Purpose Register 10 </summary> 
        public Int16 R10;
        /// <summary> General Purpose Register 11 </summary> 
        public Int16 R11;
        /// <summary> General Purpose Register 12 </summary> 
        public Int16 R12;
        /// <summary> General Purpose Register 13 </summary> 
        public Int16 R13;
        /// <summary> General Purpose Register 14 </summary> 
        public Int16 R14;
        /// <summary> General Purpose Register 15 </summary> 
        public Int16 R15;
        /// <summary> General Purpose Register 16 </summary> 
        public Int16 R16;
        /// <summary> General Purpose Register 17 </summary> 
        public Int16 R17;
        /// <summary> General Purpose Register 18 </summary> 
        public Int16 R18;
        /// <summary> General Purpose Register 19 </summary> 
        public Int16 R19;
        /// <summary> General Purpose Register 20 </summary> 
        public Int16 R20;
        /// <summary> General Purpose Register 21 </summary> 
        public Int16 R21;
        /// <summary> General Purpose Register 22 </summary> 
        public Int16 R22;
        /// <summary> General Purpose Register 23 </summary> 
        public Int16 R23;
        /// <summary> General Purpose Register 24 </summary> 
        public Int16 R24;
        /// <summary> General Purpose Register 25 </summary> 
        public Int16 R25;
        /// <summary> General Purpose Register 26 </summary> 
        public Int16 R26;
        /// <summary> General Purpose Register 27 </summary> 
        public Int16 R27;
        /// <summary> General Purpose Register 28 </summary> 
        public Int16 R28;
        /// <summary> General Purpose Register 29 </summary> 
        public Int16 R29;
        /// <summary> General Purpose Register 30 </summary> 
        public Int16 R30;
        /// <summary> General Purpose Register 31 </summary> 
        public Int16 R31;
        /// <summary> General Purpose Register 32 </summary> 
        public Int16 R32;

        /// <summary> Interrupt Address Register </summary>
        public Int16 IAR;

        /// <summary> Interrupt Data Register </summary>
        public Int16 IDR;

        /// <summary> Interrupt Flags </summary>
        public Int16 IDA;

        /// <summary> Result Hold Register </summary>
        public Int16 RHR;

        /// <summary> Last Call/Jump Address Hold Register </summary>
        public Int16 CHR;

        /// <summary> Memory Address Register </summary>
        public Int16 MAR;

        /// <summary> Memory Data Register </summary>
        public Int16 MBR;

        /// <summary> Program Counter </summary>
        public Int16 PC;

        /// <summary> Instruction Register </summary>
        public Int16 IR;

        /// <summary> Halt Bit </summary>
        public bool HALT;

        /// <summary> Carry Flag </summary>
        public bool CF;

        /// <summary> Overflow Flag </summary>
        public bool OF;

        /// <summary> Parity Flag </summary>
        public bool PF;

        /// <summary> Negative Flag </summary>
        public bool NF;

        /// <summary> Equal Flag </summary>
        public bool EQ;

        /// <summary> Not Equal Flag </summary>
        public bool NQ;

        /// <summary> Less Than Flag </summary>
        public bool LT;

        /// <summary> Greater Than Flag </summary>
        public bool GT;


        ///  Dynamically get all properties of this class
        List<FieldInfo> CurFieldInfo = typeof(Registers).GetFields().ToList();

        ///  Get Register value
        public dynamic Get(string RegisterName)
        {
            if (CurFieldInfo.Where(p => p.Name == RegisterName).Any())
            {
                /// Get FieldInfo of the matching register string
                FieldInfo x = CurFieldInfo
                              .Where(p => p.Name == RegisterName)
                              .First();

                return x.GetValue(this);
            }
            else
            {
                throw new InvalidProgramException($"Can't find Register {RegisterName}.");
            }
        }

        ///  Set Register by name
        public void Set(string RegisterName, object value)
        {
            if (CurFieldInfo.Where(p => p.Name == RegisterName).Any())
            {

                /// Get FieldInfo of the matching register string
                FieldInfo x = CurFieldInfo
                              .Where(p => p.Name == RegisterName)
                              .First();

                /// Pattern Match the value 
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