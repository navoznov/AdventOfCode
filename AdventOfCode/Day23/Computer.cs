using System;
using System.Collections.Generic;
using Day23.Instructions;

namespace Day23
{
    internal class Computer
    {
        private readonly List<Instruction> _instructions;

        public Computer(List<Instruction> instructions)
        {
            _instructions = instructions;
        }

        public void Execute()
        {
            var currentInstructionNumber = 0;
            while (true)
            {
                Instruction currentInstruction;
                try
                {
                    currentInstruction = _instructions[currentInstructionNumber];
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                var jumpInstruction = currentInstruction as JumpInstruction;
                if (jumpInstruction != null)
                {
                    if (jumpInstruction.Condition(jumpInstruction.Register))
                    {
                        currentInstructionNumber += jumpInstruction.Offset;
                        if (currentInstructionNumber > _instructions.Count - 1 || currentInstructionNumber < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        currentInstructionNumber++;
                    }
                }
                else
                {
                    ((ChangeInstruction)currentInstruction).Execute();
                    currentInstructionNumber++;
                }
            }
        }
    }
}