namespace Day07.Gates
{
    internal class AndLogicGate : BinaryLogicGate
    {
        public AndLogicGate(IHasValue source1, IHasValue source2) : base(source1, source2)
        {
        }

        public override ushort GetValue()
        {
            var value1 = Source1.GetValue();
            var value2 = Source2.GetValue();
            var result = value1 & value2;
            return (ushort)result;
        }
    }
}