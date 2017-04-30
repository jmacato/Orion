using System.Collections.Generic;
using System.Threading;
using static Orion.Constants;

namespace Orion
{
    public class Core
    {
        //Contains the raw program code to be executed
        private List<(Constants.Opcodes, short, short, short)> Program;

        //Contains active registers
        public Registers CurrentRegisterMem;

        //Current Execution Unit
        private ExecutionUnit EU;

        public Core(List<(Constants.Opcodes, short, short, short)> Program)
        {
            this.Program = Program;
            this.CurrentRegisterMem = new Registers();
            this.EU = new ExecutionUnit(ref CurrentRegisterMem);
        }

        public void Run(){
            var IsHalt = false;
            while(!IsHalt){
                IsHalt = !Step();
                Thread.Sleep(GlobalTickDurSpan);
            }
        }

        public bool Step()
        {
            var CurrentPC = CurrentRegisterMem.PC;
            var Instr = Program[CurrentPC];
            EU.ExecuteInstruction(Instr.Item1, Instr.Item2, Instr.Item3, Instr.Item4);
            if (!CurrentRegisterMem.HALT) return true; else return false;
        }
    }
}