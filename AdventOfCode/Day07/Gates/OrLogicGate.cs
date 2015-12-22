namespace Day07.Gates
{
    internal class OrLogicGate : BinaryLogicGate
    {
        public OrLogicGate(IHasValue source1, IHasValue source2)
            : base(source1, source2)
        {
        }

        public override ushort GetValue()
        {
            return (ushort)(Source1.GetValue() | Source2.GetValue());
        }
    }
}