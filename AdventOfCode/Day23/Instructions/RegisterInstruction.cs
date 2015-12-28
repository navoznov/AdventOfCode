namespace Day23.Instructions
{
    internal abstract class Instruction
    {
        public Register Register { get; private set; }

        protected Instruction(Register register)
        {
            Register = register;
        }
    }
}