namespace Day23.Instructions
{
    internal class TripleInstruction : ChangeInstruction
    {
        public TripleInstruction(Register register)
            : base(register)
        {
        }

        public override void Execute()
        {
            Register.Value *= 3;
        }
    }
}