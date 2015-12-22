namespace Day07.Gates
{
    internal class NotLogicGate : UnaryLogicGate
    {
        public NotLogicGate(IHasValue source) : base(source)
        {
        }

        public override ushort GetValue()
        {
            return (ushort)(~Source.GetValue());
        }
    }
}