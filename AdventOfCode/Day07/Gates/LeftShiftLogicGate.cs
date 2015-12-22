namespace Day07.Gates
{
    internal class LeftShiftLogicGate : ShiftGate
    {
        public override ushort GetValue()
        {
            return (ushort)(_source.GetValue() << _bitsNumber);
        }

        public LeftShiftLogicGate(IHasValue source, ushort bitsNumber) : base(source, bitsNumber)
        {
        }
    }
}