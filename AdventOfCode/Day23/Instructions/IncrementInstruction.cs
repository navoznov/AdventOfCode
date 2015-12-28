namespace Day23.Instructions
{
    internal class IncrementInstruction : ChangeInstruction
    {
        public IncrementInstruction(Register register) : base(register)
        {
        }

        public override void Execute()
        {
            Register.Value++;
        }
    }
}