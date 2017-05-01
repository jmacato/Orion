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

            if (CurrentRegisters.LT) Execute_JUMP(arg1,0,0);
        }

        private void Execute_JGT(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.GT) Execute_JUMP(arg1,0,0);
        }

        private void Execute_JEQ(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.EQ) Execute_JUMP(arg1,0,0);
        }

        private void Execute_JNE(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            if (CurrentRegisters.NQ) Execute_JUMP(arg1,0,0);
        }

        private void Execute_JUMP(Int16 arg1, Int16 arg2, Int16 arg3)
        {
            CurrentRegisters.CHR = CurrentRegisters.PC;
            CurrentRegisters.PC = (Int16)(-1 + arg1);
        }

        private void Execute_COPY(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_MOVE(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_DIV(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_MULT(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_SUB(Int16 arg1, Int16 arg2, Int16 arg3)
        {

        }

        private void Execute_ADD(Int16 arg1, Int16 arg2, Int16 arg3)
        {


            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = Enum.GetName(typeof(RegistersEnum), arg2);
            Int16 E1 = (Int16)(CurrentRegisters.Get(A1));
            Int16 E2 = (Int16)(CurrentRegisters.Get(A2));
            Int16 RX = 0;
            CurrentRegisters.OF = false;
            try
            {
                RX = (Int16)(E1 + E2);
            }
            catch (OverflowException e)
            {
                CurrentRegisters.OF = true;
            }
            catch (Exception e)
            {
                throw e;
            }

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

        private void Execute_LOAD(Int16 arg1, Int16 arg2, Int16 arg3)
        {


            var A1 = Enum.GetName(typeof(RegistersEnum), arg1);
            var A2 = arg2;

            CurrentRegisters.Set(A1, A2);

        }
    }
}