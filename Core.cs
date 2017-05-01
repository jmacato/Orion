/**************************************

    Orion Machine Code Emulator
    Main Program CPU Core
    Copyright © 2017 Jumar Macato
    
 **************************************/

using System.Threading;
using System.Collections.Generic;
using static Orion.Constants;

namespace Orion
{
    public class Core
    {
        /// <summary>Contains the raw program code to be executed</summary> 
        private List<(Constants.Opcodes, short, short, short)> Program;

        /// <summary>Contains active registers</summary> 
        public Registers CurrentRegisterMem;

        /// <summary>Current Execution Unit</summary> 
        private ExecutionUnit EU;

        /// <summary>
        /// Initialize core.
        /// </summary>
        /// <param name="Program">Program to be run.</param>
        public Core(List<(Constants.Opcodes, short, short, short)> Program)
        {
            this.Program = Program;
            this.CurrentRegisterMem = new Registers();
            this.EU = new ExecutionUnit(ref CurrentRegisterMem);
        }
        
        /// <summary>
        /// Run the program.
        /// </summary>
        public void Run(){
            var IsHalt = false;
            while(!IsHalt){
                IsHalt = !Step();
                Thread.Sleep(GlobalTickDurSpan);
            }
        }

        /// <summary>
        /// Step onto next instruction cycle.
        /// </summary>
        /// <returns>
        /// Returns if the current program can continue execution on
        /// next instruction cycle.
        /// </returns>
        public bool Step()
        {
            var CurrentPC = CurrentRegisterMem.PC;
            var Instr = Program[CurrentPC];
            EU.ExecuteInstruction(Instr.Item1, Instr.Item2, Instr.Item3, Instr.Item4);
            if (!CurrentRegisterMem.HALT) return true; else return false;
        }
    }
}