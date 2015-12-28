namespace Day23.Instructions
{
    internal class HalfInstruction : ChangeInstruction
    {
        public HalfInstruction(Register register) : base(register)
        {
        }

        public override void Execute()
        {
            Register.Value /= 2;
        }
    }
}