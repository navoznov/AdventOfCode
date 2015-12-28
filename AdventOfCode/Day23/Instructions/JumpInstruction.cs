using System;

namespace Day23.Instructions
{
    internal class JumpInstruction : Instruction, IJumpInstruction
    {
        public JumpInstruction(int offset, Func<Register, bool> condition, Register register = null) : base(register)
        {
            Offset = offset;
            Condition = condition;
        }

        public int Offset { get; private set; }
        public Func<Register, bool> Condition { get; private set; }
    }
}