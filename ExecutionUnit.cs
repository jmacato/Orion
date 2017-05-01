using System;
using System.Diagnostics;
using static Orion.Constants;

namespace Orion
{
    public class ExecutionUnit
    {
        private Registers CurrentRegisters;

        public ExecutionUnit(ref Registers currentRegisterMem)
        {
            this.CurrentRegisters = currentRegisterMem;
        }
        public void ExecuteInstruction(Opcodes Instruction, Int16 arg1, Int16 arg2, Int16 arg3)
        {
            Debug.Write($"{Instruction} ");

            Debug.WriteLine($"{arg1} {arg2} {arg3}");

            switch (Instruction)
            {
                case Opcodes.LOAD:
                    Execute_LOAD(arg1, arg2, arg3);
                    break;
                case Opcodes.ADD:
                    Execute_ADD(arg1, arg2, arg3);
                    break;
                case Opcodes.SUB:
                    Execute_SUB(arg1, arg2, arg3);
                    break;
                case Opcodes.MULT:
                    Execute_MULT(arg1, arg2, arg3);
                    break;
                case Opcodes.DIV:
                    Execute_DIV(arg1, arg2, arg3);
                    break;
                case Opcodes.MOVE:
                    Execute_MOVE(arg1, arg2, arg3);
                    break;
                case Opcodes.COPY:
                    Execute_COPY(arg1, arg2, arg3);
                    break;
                case Opcodes.CMP:
                    Execute_CMP(arg1, arg2, arg3);
                    break;
                case Opcodes.JUMP:
                    Execute_JUMP(arg1, arg2, arg3);
                    break;
                case Opcodes.JREG:
                    Execute_JREG(arg1, arg2, arg3);
                    break;
                case Opcodes.JNE:
                    Execute_JNE(arg1, arg2, arg3);
                    break;
                case Opcodes.JEQ:
                    Execute_JEQ(arg1, arg2, arg3);
                    break;
                case Opcodes.JGT:
                    Execute_JGT(arg1, arg2, arg3);
                    break;
                case Opcodes.JLT:
                    Execute_JLT(arg1, arg2, arg3);
                    break;
                case Opcodes.INTR:
                    Execute_INTR(arg1, arg2, arg3);
                    break;
                case Opcodes.INTW:
                    Execute_INTW(arg1, arg2, arg3);
                    break;
                case Opcodes.INTH:
                    Execute_INTH(arg1, arg2, arg3);
                    break;
                case Opcodes.HALT:
                    Execute_HALT();
                    break;
            }
            CurrentRegisters.PC++;
        }

        private void Execute_HALT()
        {
            CurrentRegisters.HALT = true;
        }

        private void Execute_CMP(Int16 arg1, Int16 arg2, Int16 arg3)
        {

            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            Int16 E1 = (Int16)(CurrentRegisters.Get(A1));
            Int16 E2 = (Int16)(CurrentRegisters.Get(A2));

            CurrentRegisters.Set("GT", false);
            CurrentRegisters.Set("EQ", false);
            CurrentRegisters.Set("LT", false);
            CurrentRegisters.Set("NQ", true);

            switch (E1)
            {
                case var EX when EX > E2:
                    CurrentRegisters.Set("GT", true);
                    break;
                case var EY when EY == E2:
                    CurrentRegisters.Set("EQ", true);
                    CurrentRegisters.Set("NQ", false);
                    break;
                case var EZ when EZ < E2:
                    CurrentRegisters.Set("LT", true);
                    break;
                default:
                    //Scream
                    break;
            }
        }

        private void Execute_INTH(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_INTW(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_INTR(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_JLT(Int16 arg1, Int16 arg2, Int16 arg3)
        {

            if (CurrentRegisters.LT) Execute_JUMP(arg1, 0, 0);
        }

        private void Execute_JGT(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.GT) Execute_JUMP(arg1, 0, 0);
        }

        private void Execute_JEQ(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.EQ) Execute_JUMP(arg1, 0, 0);
        }

        private void Execute_JNE(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.NQ) Execute_JUMP(arg1, 0, 0);
        }

        private void Execute_JUMP(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            CurrentRegisters.CHR = CurrentRegisters.PC;
            CurrentRegisters.PC = (Int16)(arg1 - 1);
        }

        private void Execute_JREG(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            Int16 ADDR = CurrentRegisters.Get(A1);
            Execute_JUMP(ADDR, 0, 0);
        }

        private void Execute_COPY(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            CurrentRegisters.Set(A2, CurrentRegisters.Get(A1));
        }

        private void Execute_MOVE(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            CurrentRegisters.Set(A2, CurrentRegisters.Get(A1));
            CurrentRegisters.Set(A1, 0);
        }

        private void Execute_DIV(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            Execute_MULDIV(Opcodes.DIV, arg1, arg2, arg3);
        }

        private void Execute_MULT(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            Execute_MULDIV(Opcodes.MULT, arg1, arg2, arg3);
        }

        private void Execute_SUB(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            Execute_ADDSUB(Opcodes.SUB, arg1, arg2, arg3);
        }

        private void Execute_ADD(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            Execute_ADDSUB(Opcodes.ADD, arg1, arg2, arg3);
        }

        private void Execute_ADDSUB(Opcodes Cmd, short arg1, short arg2, short arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            Int16 E1 = (Int16)(CurrentRegisters.Get(A1));
            Int16 E2 = (Int16)(CurrentRegisters.Get(A2));
            Int16 RX = 0;

            CurrentRegisters.OF = false;
            CurrentRegisters.NF = false;
            CurrentRegisters.PF = false;

            try
            {
                switch (Cmd)
                {
                    case Opcodes.ADD:
                        RX = (Int16)(E1 + E2);
                        break;
                    case Opcodes.SUB:
                        RX = (Int16)(E1 - E2);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown Command {Cmd}");
                }
            }
            catch (OverflowException e)
            {
                //Overflowed
                CurrentRegisters.OF = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            //If Result is negative int, set Negative Flag 
            if (RX < 0) CurrentRegisters.NF = true;

            //If Result is Odd, set Parity Flag
            if (RX % 2 != 0) CurrentRegisters.PF = true;

            //If Argument3 is not zero, tranfer answer to corresponding register in the arg.
            if (arg3 != 0)
            {
                var A3 = Enum.GetName(typeof(RegistersEnum), arg3);
                CurrentRegisters.Set(A3, RX);
            }
            else
            {
                CurrentRegisters.Set("RHR", RX);
            }
        }


        private void Execute_MULDIV(Opcodes Cmd, short arg1, short arg2, short arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            Int16 E1 = (Int16)(CurrentRegisters.Get(A1));
            Int16 E2 = (Int16)(CurrentRegisters.Get(A2));
            Int16 RX = 0;
            Int16 REM = 0;

            CurrentRegisters.OF = false;
            CurrentRegisters.NF = false;
            CurrentRegisters.PF = false;

            try
            {
                switch (Cmd)
                {
                    case Opcodes.MULT:
                        RX = (Int16)(E1 * E2);
                        break;
                    case Opcodes.DIV:
                        RX = (Int16)(E1 / E2);
                        REM = (Int16)(E1 % E2);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown Command {Cmd}");
                }
            }
            catch (OverflowException e)
            {
                //Overflowed
                CurrentRegisters.OF = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            //If Result is negative int, set Negative Flag 
            if (RX < 0) CurrentRegisters.NF = true;

            //If Result is Odd, set Parity Flag
            if (RX % 2 != 0) CurrentRegisters.PF = true;

            //If Argument3 is not zero, tranfer answer to corresponding register in the arg.
            if (arg3 != 0)
            {
                var A3 = Enum.GetName(typeof(RegistersEnum), arg3);
                CurrentRegisters.Set(A3, RX);
            }
            else
            {
                CurrentRegisters.Set("RHR", RX);
            }
            CurrentRegisters.Set("REM", REM);
        }
        private void Execute_LOAD(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = arg2;

            CurrentRegisters.Set(A1, A2);
        }

    }
}