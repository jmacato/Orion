using System;
using System.Diagnostics;
using static Orion.Constants;

namespace Orion
{
    public class ExecutionUnit
    {
        public void ExecuteInstruction(Opcodes Instruction, Int16 arg1, Int16 arg2, Int16 arg3)
        {
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

            }
        }

        private void Execute_INTH(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_INTW(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_INTR(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_JLT(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_JGT(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_JEQ(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_JNE(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_JUMP(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_COPY(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_MOVE(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_DIV(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_MULT(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_SUB(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_ADD(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }

        private void Execute_LOAD(short arg1, short arg2, short arg3)
        {
            Debug.WriteLine(new NotImplementedException());
        }
    }
}