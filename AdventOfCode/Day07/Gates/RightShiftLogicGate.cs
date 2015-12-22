namespace Day07.Gates
{
    internal class RightShiftLogicGate : ShiftGate
    {
        public override ushort GetValue()
        {
            return (ushort)(_source.GetValue() >> _bitsNumber);
        }

        public RightShiftLogicGate(IHasValue source, ushort bitsNumber) : base(source, bitsNumber)
        {
        }
    }
}