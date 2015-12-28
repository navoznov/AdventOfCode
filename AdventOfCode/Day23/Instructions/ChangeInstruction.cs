namespace Day23.Instructions
{
    internal abstract class ChangeInstruction : Instruction
    {
        public abstract void Execute();

        protected ChangeInstruction(Register register) : base(register)
        {
        }
    }
}